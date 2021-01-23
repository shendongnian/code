        static void Main(string[] args)
        {
            var x = GetListOfPrimes(8);
            foreach (var y in x)
            {
                Console.WriteLine(y);
            }
            Console.Read();
        }
