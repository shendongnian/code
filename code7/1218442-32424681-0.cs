        private static void Main()
        {
            char[] semicolon = new[] { ';' };
            char[] bracket = new[] { '[', ']' };
            string str = "AND[AND[Firstpart;Sndpart];sndpart]";
            string[] splitbyBracket = HideSplit(str, bracket);
        }
        private static string[] HideSplit(string str,char[] separator)
        {
            int counter = 0; // When counter is more than 0 it means we are inside brackets
            StringBuilder result = new StringBuilder(); // To build up string as result
            foreach (char ch in str)
            {
                if(ch == ']') counter--;
                if (counter > 0) // if we are inside brackets perform hide
                {
                    if (ch == '[') result.Append('\uFFF0'); // add '\uFFF0' instead of '['
                    else if (ch == ']') result.Append('\uFFF1');
                    else if (ch == ';') result.Append('\uFFF2');
                    else result.Append(ch);
                }
                else result.Append(ch);
                if (ch == '[') counter++;
            }
            return result.ToString().Split(separator).Select(x => x
                .Replace('\uFFF0', '[')
                .Replace('\uFFF1', ']')
                .Replace('\uFFF2', ';')).ToArray(); // perform split
        }
