            public static string ConvertHexToString(string HexValue)
            {
                var res = "";
                var replacedHex = HexValue.Replace("%", String.Empty);
                while (replacedHex.Length > 0)
                {
                    res += System.Convert.ToChar(System.Convert.ToUInt32(replacedHex.Substring(0, 2), 16)).ToString();
                    replacedHex = replacedHex.Substring(2, replacedHex.Length - 2);
                }
                return res;
            }
