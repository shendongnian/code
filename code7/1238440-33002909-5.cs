    string sqlqry = "insert into Table  (Date,Number) values(:Date,:Number)";
    OracleTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
    OracleCommand cmd = new OracleCommand(sqlqry, conn, trans);
    cmd.Parameters.Add(new OracleParameter("DATE", OracleDbType.Date));
    cmd.Parameters.Add(new OracleParameter("Number", OracleDbType.Decimal));
    foreach (DataGridViewRow datarow in this.dataGridView1.Rows)
    {
        cmd.Parameters[0].Value = datarow.Cells["DATE"].Value;
        cmd.Parameters[1].Value = datarow.Cells["Number"].Value;
        cmd.ExecuteNonQuery();
    }
    trans.Commit();
