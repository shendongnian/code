        public void AddPullToUser(string username, string pulledCharacter)
        {
            string jsonUserString = File.ReadAllText(userPath);
            var users = JsonConvert.DeserializeObject<List<JsonCollection.User>>(jsonUserString);
            int alreadyPulled = users.FindIndex(a => (a.username == username) && (a.pulls.FindIndex(b => b.character == pulledCharacter) > 0));
            if (alreadyPulled == -1)
            {
                int user = users.FindIndex(a => (a.username == username));
                users[user].pulls.AddRange(new List<JsonCollection.Character> { new JsonCollection.Character { character = pulledCharacter } });
                string output = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(userPath, output);
            }
        }
