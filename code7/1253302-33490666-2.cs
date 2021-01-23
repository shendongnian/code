    	Dim connectionString As StringBuilder = New StringBuilder()
        connectionString.AppendFormat("Server={0};", ????)
        connectionString.AppendFormat("Database={0};", ???)
        connectionString.AppendFormat("User ID={0};", ????)
        connectionString.AppendFormat("Password={0}", ????)
        Dim InputTable As DataTable = New DataTable("YourDataType")
        InputTable = ds.Tables(0).Copy() 
        InputTable.TableName = "YourDataType"
        Try
            Using conn As New SqlClient.SqlConnection(connectionString.ToString())
                Using comm As New SqlClient.SqlCommand()
                    Dim insertedRecords As Int32
                    comm.Connection = conn
                    comm.CommandText = "YourProcedureName"
                    comm.CommandType = CommandType.StoredProcedure
                    Dim TableVariable As SqlClient.SqlParameter = comm.Parameters.Add("@TableVariable", SqlDbType.Structured)
                    TableVariable.Direction = ParameterDirection.Input
                    TableVariable.Value = InputTable
                    Dim ScalarVariable As SqlClient.SqlParameter = comm.Parameters.Add(@ScalarParameter, SqlDbType.VarChar)
                    ScalarVariable.Direction = ParameterDirection.Input
                    ScalarVariable.Value = ???
                    conn.Open()
                    insertedRecords = comm.ExecuteNonQuery()
                    If (insertedRecords > 0) Then
                        _Changed = True
                    End If
                    conn.Close()
                    comm.Dispose()
                    conn.Dispose()
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
        Return True
