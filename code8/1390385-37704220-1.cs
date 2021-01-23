        static int LongestCharSequence(string s)
        {
            var prevChar = '\0';
            int cmax = 0;
            int max = 0;
            foreach (char c in s)
            {
                if (c != prevChar)
                {
                    cmax = 1;
                    prevChar = c;
                }
                else
                {
                    if (++cmax > max) max = cmax;
                }
            }
            return s.Length > 0 ? Math.Max(max, 1) : 0;
        }
