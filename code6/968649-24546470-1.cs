     class Program
    {
        static void Main(string[] args)
        {
            string[] test = { "one", "two", "three" }; // your string
            // make a new list of strings to contain all the strings + all the modifications
            List<string> changetest = new List<string>();
            // print out the initial array of strings
            foreach (string s in test)
                Console.WriteLine(s);
            Console.WriteLine();
            // now change the string if it starts with @
            foreach (string s in test)
                if (s.StartsWith("@"))
                    changetest.Add(s.Insert(0, "*")); // insert a *
                else
                    changetest.Add(s); // else just add
            // print out the modified list of strings
            foreach (string s in changetest)
                Console.WriteLine(s);
            Console.ReadKey();
        }
    }
