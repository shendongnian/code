    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
            Handles DataGridView1.CellContentClick
        If IsCurrentCellCheckBoxCell(sender) Then
            DirectCast(sender, DataGridView).EndEdit()
            PrintValueOfCurrentCheckBox()
            DirectCast(sender, DataGridView).BeginEdit() 'added
        End If
    End Sub
