        private static char charToReplaceWith = '_';
        static void Main(string[] args)
        {
            string s = "(x1.y2.z3 + 9.99) + y2_z1 - x1.y2.z3";
            Console.WriteLine(Regex.Replace(s, @"[a-zA-Z]+\d+\S+", new MatchEvaluator(ReplaceDotWithCharInMatch)));
            Console.Read();
        }
        private static string ReplaceDotWithCharInMatch(Match m)
        {
            return m.Value.Replace('.', charToReplaceWith);
        }
