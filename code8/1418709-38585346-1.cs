        public class User
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            string json = "{\"Id\": 1, \"Name\": \"Abdullah\"}";
            User user = JsonConvert.DeserializeObject<User>(json);
            string id = user.Id;
            string name = user.Name;
        }
