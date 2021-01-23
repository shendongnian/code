    public DataTable queryDB(string querystr) {
            DataTable res = new DataTable();
            string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\test.mdb;Persist Security Info=False;";
            OleDbConnection con =  new OleDbConnection(conStr);
            con.Open();
            OleDbDataAdapter= new OleDbDataAdapter(querystr, con);
            oDataAdapter.Fill(res);
            oDataAdapter.Dispose();
    
            con.Close();
           return res;
        }  
