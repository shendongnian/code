    public class User
    {
        public User(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["Id"];
            name = (string) jUser["Name"];
        }
        public string id { get; set; }
        public string name { get; set; }
    }
    
    // Use
    private void Run()
    {
        string json = @"{"Id": "1","Name": "A"},{"Id": "1","Name": "A"}";
        User user = new User(json);
    
        Console.WriteLine("Id : " + user.id);
        Console.WriteLine("Name : " + user.name);
     }
