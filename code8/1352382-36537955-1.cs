        public bool checkusn(String username)
        {
            MySqlDataReader reader = sendcmd("SELECT username FROM `users`");
            int foundCount = 0;
            string usernamePassedIn = username.Trim().ToUpper();
            while (reader.Read() && foundCount == 0)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string usernameReadFromDb = reader.GetString(i).Trim().ToUpper();
                    if (usernamePassedIn == usernameReadFromDb)
                        foundCount++;
                    if (foundCount > 0)
                        break;
                }
            }
            label17.Text = foundCount > 1 ? "Username already taken" : "Username not taken"
            return foundCount > 0;
        }
