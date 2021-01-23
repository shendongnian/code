    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If (e.ColumnIndex = -1) Then
            MessageBox.Show(e.RowIndex.ToString())
        End If
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If (e.ColumnIndex = -1) Then
            MessageBox.Show(e.RowIndex.ToString())
        End If
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        MessageBox.Show(e.RowIndex.ToString())
    End Sub
