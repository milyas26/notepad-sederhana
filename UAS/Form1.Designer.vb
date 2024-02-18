Imports System.IO

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.JmlhKata = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(573, 594)
        Me.TextBox1.TabIndex = 0
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(12, 653)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(280, 69)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Simpan"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnOpen
        '
        Me.BtnOpen.Location = New System.Drawing.Point(305, 653)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(280, 69)
        Me.BtnOpen.TabIndex = 2
        Me.BtnOpen.Text = "Buka File"
        Me.BtnOpen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 618)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Jumlah Kata : "
        '
        'JmlhKata
        '
        Me.JmlhKata.AutoSize = True
        Me.JmlhKata.Location = New System.Drawing.Point(108, 619)
        Me.JmlhKata.Name = "JmlhKata"
        Me.JmlhKata.Size = New System.Drawing.Size(17, 20)
        Me.JmlhKata.TabIndex = 4
        Me.JmlhKata.Text = "0"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 734)
        Me.Controls.Add(Me.JmlhKata)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnOpen)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "Notepad Sederhana"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox

    Friend WithEvents BtnSave As Button
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim MyWriter As StreamWriter
        Dim dialog As SaveFileDialog
        Dim selected As Boolean
        Dim filename As String

        dialog = New SaveFileDialog()
        selected = dialog.ShowDialog
        If selected = True Then
            filename = dialog.FileName
            MyWriter = File.CreateText(filename)
            MyWriter.WriteLine(TextBox1.Text)
            MyWriter.Close()
        End If

    End Sub

    Friend WithEvents BtnOpen As Button

    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click
        Dim MyReader As StreamReader
        Dim dialog As OpenFileDialog
        Dim selected As Boolean
        Dim filename As String

        dialog = New OpenFileDialog
        selected = dialog.ShowDialog
        If selected = True Then
            filename = dialog.FileName
            If File.Exists(filename) Then
                MyReader = File.OpenText(filename)
                TextBox1.Text = MyReader.ReadToEnd
                MyReader.Close()
            End If
        Else
            MsgBox("Tidak ada file yang dipilih!")
        End If
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents JmlhKata As Label

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim kata As String = TextBox1.Text
        Dim totalWords As Integer = 1

        For Each c As Char In kata
            If c = " " Then
                totalWords += 1
            End If
        Next

        JmlhKata.Text = totalWords
    End Sub
End Class
