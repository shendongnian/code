    public static string shita1(string st1)
        {
            int index = -1;
            string yourMatchingString = "cbc";
            while ((index = st1.IndexOf(yourMatchingString)) != -1)
                st1 = st1.Remove(index, yourMatchingString.Length);
            return st1;
        }
