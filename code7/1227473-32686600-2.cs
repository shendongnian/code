    string sql = "SELECT * FROM mySavedSelectQuery WHERE id <= 3";
    using (var cmd = new OdbcCommand(sql, con))
    {
        cmd.CommandType = System.Data.CommandType.Text;
        using (var da = new OdbcDataAdapter(cmd))
        {
            var dt = new System.Data.DataTable();
            da.Fill(dt);
            Console.WriteLine("DataTable contains {0} row(s)", dt.Rows.Count);
        }
    }
