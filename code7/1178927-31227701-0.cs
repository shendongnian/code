	public string StoragePricingDelete(string ID)
    {
        string queryStr = "DELETE FROM StoragePricing WHERE Pricing_ID = @ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
