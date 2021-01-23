        static void Main()
        {
            WorkAt(); // Prints true
            WorkAt("home"); // Prints true because the string is a compile-time constant
            // DeepClone before passing parameter to WorkAt.
            WorkAt(DeepClone("home"));// Prints false for any string.
                                      // It is only true when using the default parameter.
        }
        static void WorkAt(string location = @"home")
        {
            if (ReferenceEquals(location, @"home")) // Check out references
                                                    // Only true when using default parameter
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
        static string DeepClone(string str) // Create a deep copy
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, str);
                ms.Position = 0;
                return (string)formatter.Deserialize(ms);
            }
        }
