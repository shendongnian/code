            var dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "APE.db");
            using (var db = new SQLite.SQLiteConnection(dbPath))
            {  
                    try
                    {
                        // Delete Customer Records
                        db.Execute("DELETE FROM EstimateDetails WHERE EstimateDetailID = ?", YourValue);
                    }
                    catch (Exception ex)
                    {
                       // EXCEPTION HANDLING
                    }
                }
    
