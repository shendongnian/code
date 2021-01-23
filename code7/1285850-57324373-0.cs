    Public Class Form1
    Dim p As Point = Nothing
    Private Sub NotifyIcon1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles NotifyIcon1.MouseMove
        p = Cursor.Position
        If Not Timer1.Enabled Then
            Timer1.Start()
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        If Not Cursor.Position = p Then
            'the mouse now left the notify icon
            'write the code you want to execute when mouse leave the notify icon
            Timer1.Stop()
        End If
    End Sub
    End Class
