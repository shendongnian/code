    public static void AddOrUpdateTickRecord(TickRecord[] tickRecords)
        {
            // Create a new connection
            using (var db = new SQLiteConnection(new SQLitePlatformWinRT(), DbPath))
            {
                using (var tran = db.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        foreach (var tickRecord in tickRecords)
                        {
                            if (tickRecord.Id == 0)
                            {
                                // New
                                db.Insert(tickRecord, tran);
                            }
                            else
                            {
                                // Update
                                db.Update(tickRecord, tran);
                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }
                }
            }
        }
    
