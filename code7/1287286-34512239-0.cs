    public void SimpleDemo()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        DataTable dt = new DataTable();
    
        using (OleDbConnection cn = new OleDbConnection { ConnectionString = "TODO"})
        {
            cn.Open();
    
            using (OleDbCommand cmd = new OleDbCommand {CommandText = "TODO", Connection = cn})
            {
                OleDbDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
    
            if (dt.Rows.Count >0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // process data
                }                    
            }
        }
    }
