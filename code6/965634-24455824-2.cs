    public static void slidingText(ref string a)
        {
            string first = a.Substring(1, a.Length - 1);
            string second= a.Substring(0, 1);
            a = first + second;
        }
