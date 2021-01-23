        public void UpdateUserStats(string username, decimal value, int selection)
        {
            try
            {
                string jsonUserString = File.ReadAllText(userPath);
                var users = JsonConvert.DeserializeObject<List<JsonCollection.User>>(jsonUserString);
                int user = users.FindIndex(a => (a.username == username));
                if (user != -1)
                {
                    switch (selection)
                    {
                        case 1:
                            users[user].currency += value;
                            break;
                        case 2:
                            users[user].secondsOnline += value;
                            break;
                        default:
                            break;
                    }
                    string output = JsonConvert.SerializeObject(users, Formatting.Indented);
                    File.WriteAllText(userPath, output);
                    //AddPullToUser(username, DateTime.Now.ToString());  //remove on live
                }
                else
                {
                    CreateUser(username);
                }
            }
            catch 
            {
                Console.WriteLine("Error on UpdateCurrency");
            }
        }
