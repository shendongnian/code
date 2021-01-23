        public static void AddOrUpdateTickRecords( ObservableCollection<TickRecord> tickRecords )
            {
            // Create a new connection
            using ( var db = new SQLiteConnection( new SQLitePlatformWinRT(), DbPath ) )
                {
                db.BeginTransaction();
                try
                    {
                    foreach ( var tickRecord in tickRecords )
                        {
                        if ( tickRecord.Id == 0 )
                            {
                            // New
                            db.Insert( tickRecord );
                            }
                        else
                            {
                            // Update
                            db.Update( tickRecord );
                            }
                        }
                    db.Commit();
                    }
                catch ( Exception )
                    {
                    db.Rollback();
                    }
                }
            }
