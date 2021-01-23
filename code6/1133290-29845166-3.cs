    using (SqlCommand command = new SqlCommand(sScript, con))
    {
        paramCount = 0;
        foreach(string Id in StatusId)
        {
            string paramName = "@statusParam" + paramCount;
            command.Parameters.AddWithValue(paramName,Id);
            paramCount++;
        }
        SqlDataReader reader = command.ExecuteReader();
        /*..........rest of the code */
    }
