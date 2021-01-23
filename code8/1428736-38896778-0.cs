    private void loadRMnames()
            {
              
                List<string> namesArray = new List<string>();
                string fileName = "fieldnames.sql";
                string _path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, fileName);
    
               
                    using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), _path))
                    {
                        var regionNames = conn.Query<storeNames>(@"SELECT RM_N FROM storeNames;");
                    foreach (var names in regionNames)
                    {
                        namesArray.Add(names.RM_N);
                      
                    }
    
    
                    rmNamePick.Items.Clear();
                    rmNamePick.ItemsSource = namesArray;
    
    
                }
                }
