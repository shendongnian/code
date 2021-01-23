        static void Main(string[] args)
        {
            var s = " \r\n     6 : size=70 : <Message body> \r\n    4 : size=3 : Test.txt \r\n    17 : size=24 : Test2.txt";
            var pattern = "\n.*";
            Regex.Matches(s, pattern).Cast<Match>().Select(match => match.Value.Trim().Replace(" : ", ":")).ToList().ForEach(Console.WriteLine);
            Console.ReadKey();
        }
