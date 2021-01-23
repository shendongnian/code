    string constr = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + dbPath;
    string cmdstr = "select * from serverManagerTable";
    DataSet data = new DataSet();
    using(OleDbConnection con = new OleDbConnection(constr))
    using(OleDbCommand com = new OleDbCommand(cmdstr, con))
    {
        con.Open();
        using(OleDbDataAdapter da = new OleDbDataAdapter(com))
            da.Fill(data);
    }
    int i = data.Tables[0].Rows.Count;
    MessageBox.Show(i.ToString());
