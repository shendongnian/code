        static void Main(string[] args)
        {
            TestParseJson();
            Console.WriteLine();
            Console.WriteLine("Press Any Key to End");
            Console.ReadLine();  // Wait for input so we can see our output text
        }
        // 1 - Construct an object used for serialization/deserialization
        public class User
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public DateTime Time { get; set; }
        }
        // 2 - Simulate Json creation and then use the NewtonSoft library to deserialize.  You will need to just extract from the DeserializeObject line down
        public static void TestParseJson()
        {
            // For testing, construct Json from a list of plain-old CLR objects.  This simulates the Json from your file and looks like this:
            //"[{\"Name\":\"John\",\"Id\":45,\"Time\":\"2015-11-05T19:18:02.0324468Z\"},{\"Name\":\"Pear\",\"Id\":34,\"Time\":\"2015-11-06T19:18:02.0329474Z\"}]"
            List<User> users = new List<User>();
            users.Add(new User() { Id = 45, Name = "John", Time = DateTime.UtcNow });
            users.Add(new User() { Id = 34, Name = "Pear", Time = DateTime.UtcNow.AddDays(1) });
            string json = JsonConvert.SerializeObject(users);
            Console.WriteLine("Json: " + json);
            // Use the NewtonSoft Json library to deserialize the Json into User objects
            List<User> deserializedUsers = JsonConvert.DeserializeObject<List<User>>(json);
            // Use Linq to project the list of deserializedUsers into the lists that you want
            var names = deserializedUsers.Select(user => user.Name);
            var ids = deserializedUsers.Select(user => user.Id);
            // Output list of names and ids for debugging purposes
            Console.WriteLine("");
            Console.WriteLine("   Names:");
            foreach (var name in names)
            {
                Console.WriteLine("     " + name);
            }
            Console.WriteLine("   Ids:");
            foreach (var id in ids)
            {
                Console.WriteLine("     " + id);
            }
        }
