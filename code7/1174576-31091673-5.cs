        public static string concatStrings(string value, string value2)
        {
            string result = "";
            int i = 0;
            for (i = 0; i < Math.Max(value.Length, value2.Length) ; i++)
            {
                if (i < value.Length) result += value[i].ToString();
                if (i < value2.Length) result += value2[i].ToString();
            }
            return result;
        }
