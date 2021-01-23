        private static void Main(string[] args)
        {
            List<string> stringList = new List<string>();
            string input = "";
            while(!string.IsNullOrEmpty(input = Console.ReadLine()))
                stringList.Add(input.ToUpper().Contains("PROBLEM") ? "yes" : "no");
            foreach (var str in stringList)
                Console.WriteLine(str);
            Console.ReadKey();
        }
