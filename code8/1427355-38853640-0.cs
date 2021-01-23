    using (SqlConnection cnn = new SqlConnection(/*Connection String*/))
    {
        using (SqlCommand cmd = new SqlCommand("MyStoredProcedure", cnn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", "Value 1");
            cmd.Parameters.AddWithValue("@param2", "xxxxxx");
    
            cnn.Open();
        }
    }
