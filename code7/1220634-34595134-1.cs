    await Task.Run(() =>
    {
        ISQLitePlatform platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
        using (SQLiteConnection connection = new SQLiteConnection(platform, Path.Combine(ApplicationData.Current.LocalFolder.Path, "mydb.db")))
        {
            connection.CreateTable<Test>(); // create if not exists
            var test = new Test
            {
                Value = "test"
            };
            connection.Insert(test);
            //var lastInsertedId = platform.SQLiteApi.LastInsertRowid(connection.Handle);
            var lastInsertedId = test.Id; // more simple
            var value = connection.Find<Test>(lastInsertedId);
            Debug.WriteLine(value);
        }
    });
