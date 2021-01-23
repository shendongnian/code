    public class User
    {
        public string user { get; set; }
        public string name { get; set; }
        public string dni { get; set; }
    }
    public class TestClass
    {
        public static void Test()
        {
            var settings = new JsonSerializerSettings { ContractResolver = new StringRemappingContractResolver() };
            var user = new User { user = "usertest", name = "nametest", dni = null };
            var json = JsonConvert.SerializeObject(user, settings);
            Debug.WriteLine(json); // Prints {"user":"usertest","name":"nametest","dni":"-"}
            Debug.Assert(JToken.DeepEquals(JToken.Parse(json), JToken.Parse(@"{'user':'usertest','name':'nametest','dni':'-'}"))); // No assert
            var userBack = JsonConvert.DeserializeObject<User>(json, settings);
            Debug.Assert(user.dni == userBack.dni && user.name == userBack.name && user.user == userBack.user); // No assert
        }
    }
