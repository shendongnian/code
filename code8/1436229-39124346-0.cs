    public class Program
    {
        public static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>
            {
                ["key1"] = new List<string> { "1" },
                ["key2"] = new List<string> { "2" },
                ["key3"] = new List<string> { "3" },
            };
        
            var key = "key2";
        
            var keyValuePair = new KeyValuePair<string, List<string>>(key, dictionary[key]);
        
            Console.WriteLine(keyValuePair.Value[0]);
        }
    }
