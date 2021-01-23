        static void Main(string[] args)
        {
            var s = " \r\n     6 : size=70 : <Message body> \r\n    4 : size=3 : Test.txt \r\n    17 : size=24 : Test2.txt";
            var regex = new Regex("\n.*");
            var match = regex.Match(s);
            while (match.Success)
            {
                Console.WriteLine(match.Value.Trim().Replace(" : ", ":"));
                match = match.NextMatch();
            }
            Console.ReadKey();
        }
