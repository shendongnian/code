         public static string ConcatStrings(string value, string value2)
        {
            string result = "";
            for (int i = 0; i < value.Length && i < value2.Length; i++) result += value[i].ToString() + value2[i].ToString();
            return result;
        }
