    public static string slidingText(string a)
        {
            string first = a.Substring(1, a.Length - 1);
            string second= a.Substring(0, 1);
            return first + second;
        }
