    public async Task<int> MergeOneDataTableAsync()
    {
        // Merge One procedure
        using (SqlCommand cmd = new SqlCommand("MergeOneProcedure", dbc))
        {
            // 5 minute timeout on the query
            cmd.CommandTimeout = 300;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TVP", MergeOneDataTable);
            return await cmd.ExecuteNonQueryAsync();
        }
    }
    public async Task<int> MergeTwoDataTableAsync()
    {
        // Merge Two procedure
        using (SqlCommand cmd = new SqlCommand("MergeTwoProcedure", dbc))
        {
            // 5 minute timeout on the query
            cmd.CommandTimeout = 300;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TVP", MergeTwoDataTable);
            return await cmd.ExecuteNonQueryAsync();
        }
    }
