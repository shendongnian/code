    Dim sqlConnect As New SQLite.SQLiteConnection
        sqlConnect.ConnectionString = MyStandAloneDB.DBConnStr
        Dim sqlCmd As SQLite.SQLiteCommand = sqlConnect.CreateCommand
    
            Try
                sqlConnect.Open()
    Dim nme As String = CStr(sqlCmd.ExecuteScalar)
                TextDbName.Text = nme
    Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlCmd.Dispose()
                sqlConnect.Close()
            End Try
