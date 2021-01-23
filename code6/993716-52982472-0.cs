    using (var conn = new SqlConnection("..."))
            {
               conn.Open();
               using (var sqlTxn = conn.BeginTransaction(System.Data.IsolationLevel.Snapshot))
               {
                   try
                   {
                       using (var contextA = new ContextA(conn, contextOwnsConnection: false))
                        {
                            contextA.Database.UseTransaction(sqlTxn);
							contextA.Save(...);
							contextA.SaveChanges();
                        }
						
						using (var contextB = new ContextB(conn, contextOwnsConnection: false))
                        {
                            contextB.Database.UseTransaction(sqlTxn);
							contextB.Save(...);
							contextB.SaveChanges();
                        }
                        sqlTxn.Commit();
                    }
                    catch (Exception)
                    {
                        sqlTxn.Rollback();
                    }
                }
            }
        }
