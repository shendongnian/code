     public String FindCommonStart(string a, string b)
        {
            int length = Math.Min(a.Length, b.Length);
            var common = String.Empty;
            for (int i = 0; i < length; i++)
            {
                if (a[i] == b[i])
                {
                    common += a[i];
                }
                else
                {
                     break;
                }
            }
            return common;
        }
