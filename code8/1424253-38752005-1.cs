     private static string FormatIntString(string input)
        {
            if (input.IndexOf('.') != input.LastIndexOf('.'))
                if (input.Contains(","))
                    return DoFormat(input.Replace(".", "").Replace(',', '.'));
                else
                    return DoFormat(input.Replace(".", ""));
            else            
                if (input.Contains('.'))
                    return DoFormat(input.Replace(",", ""));
                else
                    return DoFormat(input.Replace(",", ""));            
        }
        public static string DoFormat(string myNumber)
        {
            var s = string.Format("{0:0.00}", myNumber);
            if (s[s.Length - 2] != '.')
                return (myNumber + ".0");
            else
                return s;
        }
