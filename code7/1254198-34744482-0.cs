    using (var dbConn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
        {
            var existingUser = dbConn.Query<User>("select * from User where Id = ?", user.Id).FirstOrDefault();
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Username = user.Username;
                existingUser.Surname = user.Surname;
                existingUser.EmployeeNumber = user.EmployeeNumber;
                existingUser.Password = user.Password;
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Update(existingUser);
                });
            }
        }
