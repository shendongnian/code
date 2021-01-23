        static int LongestCharSequence(string s)
        {
            var prevChar = '\0';
            int cmax = 0;
            int max = String.IsNullOrEmpty(s) ? 0 : 1;
            foreach (char c in s ?? "")
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
