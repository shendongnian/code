        static void Main(string[] args)
        {
            TestParseJson();
            Console.WriteLine();
            Console.WriteLine("Press Any Key to End");
            Console.ReadLine();  // Wait for input so we can see our output text
        }
        // 1 - Construct an object used for deserialization.  You will need to make this class match the format of the records in your json text file.
        public class User
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public DateTime Time { get; set; }
        }
        // 2 - Simulate Json creation and then use the NewtonSoft library to deserialize.  You will need to just extract from the DeserializeObject line down
        public static void TestParseJson()
        {
            // Read list of json objects from file, one line at a time.  The json in the test file users.json is in this format:
            // {"Name":"John","Id":45,"Time":"2015-11-05T19:18:02.0324468Z"}
            // {"Name":"Pear","Id":34,"Time":"2015-11-06T19:18:02.0329474Z"}
            var jsonLines = File.ReadLines(@"c:\temp\users.json");
            var deserializedUsers = jsonLines.Select(JsonConvert.DeserializeObject<User>).ToList();
            // Use Linq to project the list of deserializedUsers into the lists that you want
            var names = deserializedUsers.Select(user => user.Name);
            var ids = deserializedUsers.Select(user => user.Id);
            // Output list of names and ids for debugging purposes
            Console.WriteLine("");
            Console.WriteLine("   Names:");
            foreach (var name in names)
            {
                Console.WriteLine("      " + name);
            }
            Console.WriteLine("   Ids:");
            foreach (var id in ids)
            {
                Console.WriteLine("      " + id);
            }
        }
