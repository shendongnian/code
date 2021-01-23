    private void writeRecord(DataGridViewRow datarow)
    {
        string sqlqry = "insert into Table (Date,Number) values(:Date,:Number)";
        OracleCommand cmd = new OracleCommand(sqlqry, conn);
        cmd.Parameters.Add(new OracleParameter("Date", datarow["DATE"]))
        cmd.Parameters.Add(new OracleParameter("Number", datarow["Number"]));
        // cmd.CommandText = sqlqry;  -- not necessary, handled in constructor
        cmd.ExecuteNonQuery();
    }
