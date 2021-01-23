    Using transaction As OleDbTransaction = myconnection.BeginTransaction()
    	Try    	
    		Dim id As Integer
    		For Each id In ids
    			Using cmd2 As New OleDbCommand(updateRoute, myconnection, transaction)
    				cmd2.Parameters.AddWithValue("?", id)
    				cmd2.Parameters.AddWithValue("?", id)
    				cmd2.ExecuteNonQuery()
    			End Using
    		Next
    		transaction.Commit()
    	Catch
    		transaction.RollBack();
    	End Try		
    End Using
