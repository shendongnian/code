        public void CreateUser(string username)
        {
            try
            {
                string jsonUserString = File.ReadAllText(userPath);
                var users = JsonConvert.DeserializeObject<List<JsonCollection.User>>(jsonUserString);
                users.AddRange(new List<JsonCollection.User> { new JsonCollection.User { username = username, currency = 10, pulls = new List<JsonCollection.Character> { new JsonCollection.Character { character = "TemmieHYPE" } } } });
                string output = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(userPath, output);
            }
            catch
            {
                Console.WriteLine("Error on CreateUser");
            }
        }
