    public static async Task BuildDB(string ParseFileName)
            {
                string templateSql = SqliteController.tempFile() + "Tables.sql";
                IEnumerable Lines;
                List<string> LineUnformatted = new List<string>();
                Task<bool> returnedTaskTResult = SqliteController.TemplateSql();
                bool result = await returnedTaskTResult;
    
                if (result)
                {
                    Lines = File.ReadLines(templateSql);
                    foreach (string v in Lines)
                    {
                        LineUnformatted.Add(v);
                    }
                }
    
                List<string> LineResults = new List<string>();
                foreach (string q in LineUnformatted)
                {
                    LineResults.Add(q);
                }
                string FileName = ParseFileName;
    
                SQLiteConnection.CreateFile(FileName);
                using (SQLiteConnection con = new SQLiteConnection("data source=" + FileName + ";Version=3;Pooling=False;"))
                {
                    await con.OpenAsync();
    
                    SQLiteCommand cmd = new SQLiteCommand(con);
    
                    using (var transaction = con.BeginTransaction())
                    {
    
                        Trace.TraceInformation("Starting the SQLCMD Builder");
    
                        foreach (string liner in LineResults)
                        {
                            cmd.CommandText = liner;
    
                            try
                            {
                                await cmd.ExecuteNonQueryAsync();
                            }
                            catch (SQLiteException)
                            {
                                Trace.TraceError("An Error Occoured Executing the Query");
                            }
                        }
                        Trace.TraceInformation("Transaction Commited");
                        transaction.Commit();
                        cmd.Dispose();
                        transaction.Dispose();
                    }
    
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
    
                    Trace.TraceInformation("Sqlite Data Connection Close File Generation Complete.");
                }
            }
