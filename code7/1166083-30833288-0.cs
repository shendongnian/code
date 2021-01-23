    using (OracleCommand cmd = new OracleCommand())
    {
        cmd.Connection = conn;
        cmd.CommandText = "select * from table(return_table())";
        cmd.CommandType = CommandType.Text;
        conn.Open();
        OracleDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Console.WriteLine(rdr.GetOracleDecimal(0));
            Console.WriteLine(rdr.GetOracleString(1));
        }
        conn.Close();
    }
