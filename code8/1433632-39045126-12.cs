    Dim InputIsCommand As Boolean = False
    Private Sub TextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        InputIsCommand = e.Control = True AndAlso (e.KeyCode = Keys.V OrElse e.KeyCode = Keys.C)
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        e.Handled = Not InputIsCommand
    End Sub
