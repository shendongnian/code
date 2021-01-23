    Dim CommandIsPaste As Boolean = False
    Private Sub TextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.Control = True AndAlso e.KeyCode = Keys.V Then
            CommandIsPaste = True
        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        e.Handled = Not CommandIsPaste
    End Sub
