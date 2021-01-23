        static void Main(string[] args)
        {
            WorkAt(); // prints true
            WorkAt("home"); // prints true because string is compile-time constant
            string test = new string(new []{'h','o','m','e'});
            // or
            // string test = Console.ReadLine(); // input => home
            // or other ways like create deep copy from object
            WorkAt(test); // prints false
        }
        static void WorkAt(string location = @"home")
        {
            if (ReferenceEquals(location, @"home"))
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
