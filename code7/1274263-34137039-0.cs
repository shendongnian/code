    Private Sub dgv1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv1.ColumnHeaderMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            MsgBox(e.ColumnIndex & " " & dgv1.Columns(e.ColumnIndex).Name & " " & dgv1.Columns(e.ColumnIndex).HeaderText)
        End If
    End Sub
