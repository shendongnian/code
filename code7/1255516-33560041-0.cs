          const string FILENAME = @"\temp\test.txt";
            static void Main(string[] args)
            {
                string input = File.ReadAllText(FILENAME);
                string pattern = "^[^:]\\s+\"";
                MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Multiline);
            }​
