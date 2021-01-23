        readonly IComparer<char> charComparer;
        public CustomStringComparer(IComparer<char> charComparer)
        {
            this.charComparer = charComparer;
        }
        public int Compare(string a, string b)
        {
            int result = 0;
            for (int i = 0; (i < a.Length || i < b.Length) && result == 0 ; i++)
            {
                if (i >= a.Length || i >= b.Length)
                {
                    return i >= a.Length ? -1 : 1;
                }
                result = charComparer.Compare(a[i], b[i]);
            }
            return result;
        }
    }
