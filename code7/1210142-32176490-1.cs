        static void Main(string[] args)
        {
            string test = new string(new []{'h','o','m','e'});
            // or
            // string test = Console.ReadLine(); // input => home
            // or other ways like create deep copy from object
            Test(); // prints true
            Test(test); // prints false
        }
        static void Test(string location = @"home")
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
