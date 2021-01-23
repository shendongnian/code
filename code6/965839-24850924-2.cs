        private List<DataTable> getMovieTables()
        {
            List<DataTable> movieTables = new List<DataTable>();
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                DataRowCollection sheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" }).Rows;
                foreach (DataRow sheet in sheets)
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM [" + sheet["TABLE_NAME"].ToString() + "] ";
                        var adapter = new OleDbDataAdapter(cmd);
                        var ds = new DataSet();
                        try
                        {
                            adapter.Fill(ds);
                            movieTables.Add(ds.Tables[0]);
                        }
                        catch (Exception ex)
                        {
                            //Debug.WriteLine(ex.ToString());
                            continue;
                        }
                    }
                }
            }
            return movieTables;
        }
