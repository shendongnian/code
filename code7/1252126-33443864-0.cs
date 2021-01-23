    public void DeleteDataRow(string ID)
    {
    	using (SqlCommand xComm = new SqlCommand("Delete from Customers Where CID='" + ID + "' ", Conn))
    	{
    		Conn.Open();
    		int result = xComm.ExecuteNonQuery();
    		Conn.Close();
    	}
    }
