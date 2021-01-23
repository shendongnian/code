        public bool checkusn(String username)
        {
            MySqlDataReader reader = sendcmd("SELECT username FROM `users`");
            bool taken = true;
            string usernamePassedIn = username.Trim().ToUpper();
            while (reader.Read() && !taken)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string usernameReadFromDb = reader.GetString(i).Trim().ToUpper();
                    taken = usernamePassedIn == usernameReadFromDb;
                    if (taken)
                        break;
                }
            }
            label17.Text = taken ? "Username already taken" : "Username not taken"
            return taken;
        }
