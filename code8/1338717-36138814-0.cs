          Using transaction As OleDbTransaction = myconnection.BeginTransaction()            
            Dim id As Integer
            Dim errors as Integer = 0
            For Each id In ids
                Using cmd2 As New OleDbCommand(updateRoute, myconnection, transaction)
                    cmd2.Parameters.AddWithValue("?", id)
                    cmd2.Parameters.AddWithValue("?", id)
                    Try 
                      cmd2.ExecuteNonQuery()
                    Catch
                      errors+=1
                    End Try
                End Using
            Next
    
            If errors=0
              transaction.Commit()
            else
              transaction.RollBack();
            End If    
          End Using
