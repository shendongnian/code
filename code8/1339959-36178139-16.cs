    Public Shared Sub InsertUpdateDataTable(strTableName As String, dt As System.Data.DataTable)
        Dim strSQL As String = String.Format("SELECT * FROM [{0}] WHERE 1 = 2 ", strTableName.Replace("]", "]]"))
        Using daInsertUpdate As New System.Data.SqlClient.SqlDataAdapter(strSQL, getConnectionString())
            Dim cmdBuilder As New SqlCommandBuilder(daInsertUpdate)
            daInsertUpdate.InsertCommand = cmdBuilder.GetInsertCommand()
            daInsertUpdate.UpdateCommand = cmdBuilder.GetUpdateCommand()
            daInsertUpdate.Update(dt)
        End Using
    End Sub
