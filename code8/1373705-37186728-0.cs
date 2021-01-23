     public static string GetCharOnly(string str)
        {
            if (String.IsNullOrEmpty(str))
                return string.Empty;
            var result = new StringBuilder();
            foreach (char c in str)
            {
                if (!Char.IsDigit(c))
                    result.Append(c);
            }
            return result.ToString();
        }
