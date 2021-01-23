    public DataTable GetData(string connstr, string qrystr)
        {
            var conn = new System.Data.OleDb.OleDbConnection(@connstr);
            conn.Open();
            OleDbCommand comm = new System.Data.OleDb.OleDbCommand(qrystr, conn);
            DataTable dtbl = new DataTable();
            dtbl.Load(comm.ExecuteReader());
            return dtbl;
        }
