    SQLiteConnection connSqlite = new SQLiteConnection(string.Format("Data Source={0};Version=3;", filepath));
                connSqlite.Open();
                    DataTable a = new DataTable();
                    for (int i = 0; i < a.Rows.Count; i++)
                    {
                        string rowquery = "insert into tbl values(";
                        for (int z = 0; z < a.Rows[i].ItemArray.Count(); z++)
                        {
                            rowquery+=a.Rows[0].ItemArray[1].ToString();
                            if (z < a.Rows[i].ItemArray.Count() - 1)
                                rowquery += ",";
                        }
                        rowquery += ")";
                    }
                    SQLiteCommand commSqlite = new SQLiteCommand(strCommand, connSqlite);
                    commSqlite.ExecuteNonQuery();
