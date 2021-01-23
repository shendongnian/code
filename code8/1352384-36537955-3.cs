        public bool checkusn(String username)
        {
            MySqlDataReader reader = sendcmd("SELECT username FROM `users`");
            int foundCount = 0;
            string usernamePassedIn = username.Trim().ToUpper();
            while (reader.Read() && foundCount == 0)
            {
                    string usernameReadFromDb = reader.GetString(0).Trim().ToUpper();
                    if (usernamePassedIn == usernameReadFromDb)
                        foundCount++;
                }
            label17.Text = foundCount > 1 ? "Username already taken" : "Username not taken";
            return foundCount > 0;
        }
