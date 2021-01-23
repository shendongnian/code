        static void Main(string[] args)
        {
            string pattern = @"^.*\s+(\d\d-...-2\d\d\d)\s+Time:\s+(\d\d:\d\d:\d\d)";
            string input = "The product must be shipped by 25-Dec-2015 Time: 12:30:00";
            Match match = Regex.Match(input, pattern);
            
            string date = match.Groups[1].Value;
            string time = match.Groups[2].Value;
            string concatenated = date + " " + time;
            Console.WriteLine(concatenated);
        }
