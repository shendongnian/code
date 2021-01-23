    class Program
    {
        static void Main(string[] args)
        {
            string original = "hi. i'm Matteo and work in IP";
            Console.WriteLine(Regex.Replace(original, @"\A[a-z]|(?<=\W{2})[a-z]", new MatchEvaluator(CapText), RegexOptions.ECMAScript));
            Console.ReadKey();
        }
        static string CapText(Match match)
        {
            string tempStr = match.ToString();
            if (char.IsLower(tempStr[0]))
            {
                return char.ToUpper(tempStr[0]) + tempStr.Substring(1, tempStr.Length - 1);
            }
            return tempStr;
        }
    }
