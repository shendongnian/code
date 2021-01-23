     public String FindCommonStart(string a, string b)
        {
            int length = a.Length;
            if (b.Length < length)
            {
                length = b.Length;
            }
            var common = String.Empty;
            for (int i = 0; i < length; i++)
            {
                if (a[i] == b[i])
                {
                    common += a[i];
                }
            }
            return common;
        }here
