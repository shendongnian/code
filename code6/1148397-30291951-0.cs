    using (SqlConnection conn = new SqlConnection("FULL CONNECTION STRING")) // Can also retrieve using ConfigurationManager or WebConfigurationManager
    {
        using (SqlCommand cmd = new SqlCommand("INSERT INTO table1 (col1) VALUES (@Val1)", conn))
        {
            cmd.CommandType = CommandType.Text;
            SqlParameter sp = new SqlParameter("@Var1", SqlDbType.VarChar);
            sp.Direction = ParameterDirection.Input;
            sp.Value = var1;
            cmd.Parameters.Add(sp);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
