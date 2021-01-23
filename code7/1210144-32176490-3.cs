        static void Main(string[] args)
        {
            WorkAt(); // prints true
            WorkAt("home"); // prints true because string is compile-time constant
            
            // DeepClone string
            WorkAt(DeepClone("home"));// Prints false for any string.
                                      // only true when using default parameter
        }
        static void WorkAt(string location = @"home")
        {
            if (ReferenceEquals(location, @"home")) // Check out references
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
        static string DeepClone(string str) // Create Deep copy
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, str);
                ms.Position = 0;
                return (string)formatter.Deserialize(ms);
            }
        }
