        static void Main(string[] args)
        {
            Test(); // prints true
            Test("..."); // prints false
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
