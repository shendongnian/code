    Private Sub dataGridView2_RowEnter(ByVal sender As Object, _
    ByVal e As DataGridViewCellEventArgs) _
    Handles DataGridView2.RowEnter
       
        Dim collab As String = DataGridView2.Rows(e.RowIndex).Cells("RefDataGridViewTextBoxColumn").Value
        Dim cell As DataGridViewComboBoxCell = DataGridView2.Rows(e.RowIndex).Cells("Poles")
        Try
            Conn.Open()
            Dim query As String = "Select Label From equipe_collab where ref_collab ='" + collab + "'  "
            Dim cmd As New OleDbCommand(query, Conn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            cell.Items.Clear()
            Do While dr.Read = True
                cell.Items.AddRange(dr.Item(0))
            Loop
 
            cell.Value = cell.Items(0)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
  
