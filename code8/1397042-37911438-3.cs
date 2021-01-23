    class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 0, 25, 26, 675, 676 };
            foreach (int value in values)
            {
                Console.WriteLine("{0}: {1}", value, ToBase26AlphaString(value));
            }
            Console.WriteLine();
            List<Tuple<int, string>> hackedValues = new List<Tuple<int, string>>();
            for (int i = 0; i < 531441; i++)
            {
                string text = ToBase27AlphaString(i);
                if (!text.Contains('`'))
                {
                    hackedValues.Add(Tuple.Create(i, text));
                }
            }
            Tuple<int, string> prev = null;
            for (int i = 0; i < hackedValues.Count; i++)
            {
                Tuple<int, string> current = hackedValues[i];
                if (prev == null || prev.Item2.Length != current.Item2.Length)
                {
                    if (prev != null)
                    {
                        DumpHackedValue(prev, i - 1);
                    }
                    DumpHackedValue(current, i);
                }
                prev = current;
            }
        }
        private static void DumpHackedValue(Tuple<int, string> hackedValue, int i)
        {
            Console.WriteLine("{0}: {1} (actual value: {2})", i, hackedValue.Item2, hackedValue.Item1);
        }
        static string ToBase26AlphaString(int value)
        {
            return ToBaseNAlphaString(value, 'a', 26);
        }
        static string ToBase27AlphaString(int value)
        {
            return ToBaseNAlphaString(value, '`', 27);
        }
        static string ToBaseNAlphaString(int value, char baseChar, int numericBase)
        {
            StringBuilder sb = new StringBuilder();
            while (value > 0)
            {
                int digit = value % numericBase;
                sb.Append((char)(baseChar + digit));
                value /= numericBase;
            }
            if (sb.Length == 0)
            {
                sb.Append(baseChar);
            }
            sb.Reverse();
            return sb.ToString();
        }
    }
    static class Extensions
    {
        public static void Reverse(this StringBuilder sb)
        {
            for (int i = 0, j = sb.Length - 1; i < sb.Length / 2; i++, j--)
            {
                char chT = sb[i];
                sb[i] = sb[j];
                sb[j] = chT;
            }
        }
    }
