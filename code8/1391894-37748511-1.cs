    public static string[] Split(string s)
    {
        List<string> strings = new List<string>();
        int index = 0;
        while (index < s.Length)
        {
            if (s.Substring(index, 1) == "[")
            {
                int length = s.IndexOf("]", index + 1) - (index + 1);
                string s2 = s.Substring(index + 1, length);
                strings.Add(s2);
                index += s2.Length + 2;
            }
            else index++;
        }
        return strings.ToArray();
    }
