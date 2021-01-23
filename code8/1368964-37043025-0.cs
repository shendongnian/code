    using (SqlConnection connection = new SqlConnection(this.connectionString))
    {
        connection.Open();
        SqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = @"Insert into TB_LN_CASES (col1, col2,col3, ..) 
                            Values (@value1, @value2, @value3, ..) ";
        cmd.Parameters.Add(new SqlParameter("@value1", value1));
        cmd.Parameters.Add(new SqlParameter("@value2", value2));
        cmd.Parameters.Add(new SqlParameter("@value3", value3));
        cmd.ExecuteNonQuery();
    }
