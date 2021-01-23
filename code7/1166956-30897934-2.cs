        public DataTable ExcelToDataTable(string fullFilename, string tableName)
        {
            var table = new DataTable();
            string strCon = string.Format(EXCEL_CON, fullFilename);
            using (var con = new System.Data.OleDb.OleDbConnection(strCon))
            {
                ConnectionState initialState = con.State;
                try
                {
                    if ((initialState & ConnectionState.Open) != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    string sql = string.Format("SELECT * FROM `{0}`;", tableName);
                    using (var cmd = new System.Data.OleDb.OleDbCommand(sql, con))
                    {
                        table.Load(cmd.ExecuteReader());
                    }
                }
                finally
                { // it seems like Access does not always close the connection
                    if ((initialState & ConnectionState.Open) != ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return table;
        }
