    public DataTable access2dt(string filename, string namaQuery, IDictionary<string,string> keyValue)
        {
    
            string myConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=test.accdb";
            using (var con = new OleDbConnection(myConnectionString))
            {
                con.Open();
    
                using (var cmd = new OleDbCommand("EXEC OUTBOUND_FILTER",con))
                {
                  foreach (var d in keyValue)
                {
                     cmd.Parameters.AddWithValue(d.Key, d.Value);
                }
                    using (OleDbDataReader rdr = cmd.ExecuteReader())
    
                    {
                        DataTable myTable = new DataTable();
                        myTable.Load(rdr);
                        return myTable;
                    }
    
    
                }
    
            }
        }
