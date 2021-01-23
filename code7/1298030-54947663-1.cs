    Private Sub Connect(srcDT As DataTable, spParameter As String)
        Dim conString As String = GetConnectionString()
        Dim oSqlConnection As SqlConnection = New SqlConnection(conString)
        Try
            Dim oSqlCommand = New SqlCommand("Create Table #STG1 (
	            [Username] [nvarchar](100) NULL,
	            [FirstName] [nvarchar](100) NULL,
	            [LastName] [nvarchar](100) NULL,
	            [Active] [bit] NULL,
	            [Department] [nvarchar](100) NULL
            )", oSqlConnection) With {
            .CommandType = CommandType.Text,
            .CommandTimeout = 0
        }
            oSqlConnection.Open()
            oSqlCommand.ExecuteNonQuery()
            Dim oSqlBulkCopy As SqlBulkCopy = New SqlBulkCopy(oSqlConnection) With {
            .DestinationTableName = "#STG1"
        }
            oSqlBulkCopy.WriteToServer(srcDT)
            Dim command As New SqlCommand("spName", oSqlConnection) With {
            .CommandType = CommandType.StoredProcedure
        }
            command.Parameters.AddWithValue("@inParam", spParameter)
            command.ExecuteScalar()
        Finally
            oSqlConnection.Close()
            oSqlConnection.Dispose()
        End Try
    End Sub
