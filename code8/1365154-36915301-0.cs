	using (TransactionScope scope = new TransactionScope())
	{
		using (SqlConnection connection1 = new SqlConnection(connectString1))
		{
			// according to the documentation on TransactionScope
			// Opening the connection automatically enlists it in the 
			// TransactionScope as a lightweight transaction.
			con.Open();
			
			// I changed this to make it parameterized as well although this had nothing to do with the TransactionScope question
			SqlCommand updateCmd = new SqlCommand("UPDATE V_Stock SET Quantity= 5 WHERE Id= @shelfId", con);
			updateCmd.Parameters.AddWithValue("@shelfId", shelfId);
			
			SqlCommand insertCmd = new SqlCommand("INSERT INTO V_Stock (Code, Quantity, Name) VALUES (@1, @2, @3)", con);
			insertCmd.Parameters.AddWithValue("@1", "Code1");
			insertCmd.Parameters.AddWithValue("@2", 15);
			insertCmd.Parameters.AddWithValue("@3", "Name1");
			updateCmd.ExecuteNonQuery();
			insertCmd.ExecuteNonQuery();            
			
			// according to the documentation on TransactionScope
			// The Complete method commits the transaction. If an exception has been thrown,
			// Complete is not  called and the transaction is rolled back.
			scope.Complete();
		}
	}
