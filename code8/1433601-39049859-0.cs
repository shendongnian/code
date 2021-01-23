    Private Sub BackGroundWorkerAdhoc_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackGroundWorkerAdhoc.DoWork
        Try
            Using myNewConn As New SqlConnection(...)
                Load_n_ExecuteProc(myNewConn)
            End Using
        Catch ex As Exception
            ErrorHandler("frmAdhocRptGenerator.subBackGroundWorkerAdhoc_DoWork", ex.ToString)
        End Try
    End Sub
    Private Function Load_n_ExecuteProc(theConn As SqlConnection) As Boolean
        Try
            cmdPROVIDER_FINDER = New SqlCommand("SP$PROVIDER_FINDER", tmpConn)
            cmdPROVIDER_FINDER.CommandType = CommandType.StoredProcedure
            cmdPROVIDER_FINDER.CommandTimeout = 10000
            Dim rst As Integer = cmdPROVIDER_FINDER.ExecuteNonQuery()
            return = rst > -1
        Catch ex As Exception
            ErrorHandler("frmAdhocRptGenerator.Load_n_ExecuteProc", ex.ToString)            
        Finally
            cmdPROVIDER_FINDER = Nothing
        End Try
    End Function
    Public Sub CancelSqlCommand()
        Dim cmd = cmdPROVIDER_FINDER
        If cmd isnot Nothing cmd.Cancel()
    End Sub
