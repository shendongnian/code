    Public Class Form2
    
      Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.ComboBox1.Text = ""
        Me.ComboBox1.Items.Add("a")
        Me.ComboBox1.Items.Add("aaa")
        Me.ComboBox1.Items.Add("combo")
        Me.ComboBox1.Items.Add("combobox")
        Me.ComboBox1.Items.Add("combobox test")
        Me.ComboBox1.Items.Add("common")
        Me.ComboBox1.Items.Add("common dialog")
      End Sub
    
      Private Sub ComboBox1_TextChanged(sender As Object, e As System.EventArgs) Handles ComboBox1.TextChanged
        Dim count As Integer = 0
    
        For Each op As String In ComboBox1.Items
          If (op Is Nothing OrElse op.Length < ComboBox1.Text.Length) Then
            Continue For
          End If
          If (ComboBox1.Text = op.Substring(0, ComboBox1.Text.Length)) Then
            count += 1
          End If
        Next
    
        Label1.Text = count
      End Sub
    
    End Class
