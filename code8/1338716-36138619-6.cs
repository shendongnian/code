    Using transaction As OleDbTransaction = myconnection.BeginTransaction()
    	Try    	
    		Dim id As Integer
    		Dim b As New StringBuilder()
    		
    		For Each id In ids
    			b.AppendFormat("UPDATE [Routes] SET [matching_route_id] = {0} WHERE [ID] = {0}; ", id)
    		Next
    		
    		Using cmd2 As New OleDbCommand(updateRoute, myconnection, transaction)				
    			cmd2.ExecuteNonQuery()
    		End Using
    		transaction.Commit()
    	Catch
    		transaction.RollBack();
    	End Try		
    End Using
