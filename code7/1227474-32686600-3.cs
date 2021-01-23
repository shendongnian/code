    string sql = "{CALL mySavedParameterQuery (?)}";
    using (var cmd = new OdbcCommand(sql, con))
    {
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        // set parameter values (if any) in the order that they appear 
        //     in the PARAMETERS list of the saved query
        cmd.Parameters.Add("?", OdbcType.Int).Value = 3;
        using (var da = new OdbcDataAdapter(cmd))
        {
            var dt = new System.Data.DataTable();
            da.Fill(dt);
            Console.WriteLine("DataTable contains {0} row(s)", dt.Rows.Count);
        }
    }
    
