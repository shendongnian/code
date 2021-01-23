    public class Program
    {
        public class User
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            IList<User> Users = new List<User>();
            string json = "{\"Id\": 1, \"Name\": \"Ben\"},{\"Id\": 2, \"Name\": \"Danny\"}";
            string[] jsonArray = json.Split(new string[] { "},{" }, StringSplitOptions.None);
            foreach (string j in jsonArray)
            {
                string jsonTemp = j.Replace("{", "").Replace("}", "");
                string myJson = "{" + jsonTemp + "}";
                Users.Add(JsonConvert.DeserializeObject<User>(myJson));
            }
        }
    }
