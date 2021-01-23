    Private Sub DataGridView2_RowEnter(sender As Object, e As DataGridViewCellEventArgs)
        ' get here the row values to be used to determine the ComboBox content
        ' Adapt the 2 following lines
        Dim col1Value As Integer = CInt(DataGridView2.Rows(e.RowIndex).Cells("col1Name").Value)
        Dim collab As String = DirectCast(DataGridView2.Rows(e.RowIndex).Cells("RefDataGridViewTextBoxColumn").Value, String)
        Dim PoleValues As List(Of String) = New List(Of [String])()
        ' Here, your code to add to PoleValues the ComboBox values from colXValues
        ' ...  
        Try
            Conn.Open()
            Dim query As String = "Select Label From equipe_collab where ref_collab='" + collab + "'"
            Dim cmd As New OleDbCommand(query, Conn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            Do While dr.Read = True
                PoleValues.Add(dr.Item(0))
            Loop
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '
        ' I want to add items to combobox(col 2) using the ref of collab (col1) in thee same line 
        '  so I will not convert the same column from textbox to columnbox
        ' 
        Dim cb As DataGridViewComboBoxColumn = DirectCast(DataGridView2.Columns("RefDataGridViewTextBoxColumn"), DataGridViewComboBoxColumn)
        cb.Items.Clear()
        cb.Items.AddRange(PoleValues)
    End Sub
