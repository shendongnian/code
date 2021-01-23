	string sql = "select *redacted* from " + tableref + " where *redacted* = @InvoiceParam";
	using (var adapter = new SqlDataAdapter(sql, DBConnection.DBConnection.connectionString))
	{
		adapter.SelectCommand.Parameters.AddWithValue("@InvoiceParam", invRef);
		adapter.Fill(holdall);
		invoiceTable = holdall.Tables[0];
	}
