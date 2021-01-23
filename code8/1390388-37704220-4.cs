        static int LongestCharSequence(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var prevChar = '\0';
            int cmax = 0;
            int max = 1;
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
            return max;
        }
