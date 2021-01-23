    private void Insert_Click(object sender, RoutedEventArgs e)    
            {
                using (var db = new SQLiteConnection(DB_PATH))
                {
                    db.RunInTransaction(() =>
                    {
                        foreach(int id in IDs)
                        {
                            db.Insert(new Task() { IDs[id-1], FirstNames[id-1], LastNames[id-1], CreationDate = DateTime.Now });
                        }
                    });
                }
            }
