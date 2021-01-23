    class Program
    {
        static void Main(string[] args)
        {
            string input = "This is is a test.... 12345";
            // Here we call Regex.Match.
            MatchCollection matches = Regex.Matches(input, @"(?<MySentence>(\w+\s*)*)(?<MyNumberPart>\d*)");
            foreach (Match item in matches)
            {
                Console.WriteLine(item.Groups["MySentence"]);
                Console.WriteLine("******");
                Console.WriteLine(item.Groups["MyNumberPart"]);
            }
            Console.ReadKey();
        }
    }
