    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            string a = "ATTAGACCTGCCGGAA";
            string b = "GCCGGAATAC";
            string match = test.Match(a, b); // GCCGGAA
            if (match != null)
            {
                string c = a.Remove(a.IndexOf(match), match.Length); // ATTAGACCT
                Console.WriteLine(c);
            }
        }
    }
    class Test
    {
        public string Match(string a, string b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            if (b == null)
            {
                throw new ArgumentNullException("b");
            }
            string best = null;
            for (int i = 0; i < b.Length; i++)
            {
                string match = Match(a, b, i);
                if (match != null && (best == null || match.Length > best.Length))
                {
                    best = match;
                }
            }
            return best;
        }
        private string Match(string a, string b, int offset)
        {
            string best = null;
            for (int i = offset; i < b.Length; i++)
            {
                string s = b.Substring(offset, (i - offset) + 1);
                int index = a.IndexOf(s);
                if (index != -1)
                {
                    best = s;
                }
            }
            return best;
        }
    }
