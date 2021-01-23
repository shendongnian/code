    Public Class Form1
    
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
    
            Dim Strip As New ContextMenuStrip
            Dim Item1, Item2 As ToolStripMenuItem
    
            Item1 = New ToolStripMenuItem("Test1", Nothing, AddressOf DoTestAction)
            Item2 = New ToolStripMenuItem("Google", Nothing, AddressOf DoGoogle)
            Strip.Items.Add(Item1)
            Strip.Items.Add(Item2)
    
            Me.WebBrowser1.ContextMenuStrip = Strip
    
        End Sub
    
        Public Sub DoTestAction(sender As Object, e As EventArgs)
            MessageBox.Show("Testing")
        End Sub
    
        Public Sub DoGoogle(sender As Object, e As EventArgs)
            Me.WebBrowser1.Navigate("http://www.google.com")
        End Sub
    
    End Class
