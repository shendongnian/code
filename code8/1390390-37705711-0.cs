        int LongestCharSequence(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            int i = 1;
            for (; i < s.Length; i++)
            {
                if (s[i] != s[i - 1]) return Math.Max(i, LongestCharSequence(s.Substring(i)));
            }
            return i;
        }
