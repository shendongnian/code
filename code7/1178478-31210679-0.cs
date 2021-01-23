      string str = "User ID=username;Password=password;Data Source=Test";
        OracleConnection conn = new OracleConnection(str);
        OracleCommand cmd = new OracleCommand("PROCEDURE2", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        --Ad parameter list--
        // cmd.Parameters.Add("parameter_name", "varchar2").Value = value;
        ....
        conn.Open();
        cmd.ExecuteNonQuery();
