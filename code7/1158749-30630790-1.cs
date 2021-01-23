    private static void CountGroupOccurrences(string str, params string[] patterns)
    {
        string result = string.Empty;
        while (str.Length > 0)
        {
            foreach (string pattern in patterns)
            {
                int count = 0;
                int index = str.IndexOf(pattern); 
                while (index > -1)
                {
                    count++;
                    str = str.Remove(index, pattern.Length);
                    index = str.IndexOf(pattern); 
                }
                result += string.Format("{0}({1})", count, pattern);
            }
        }
        Console.WriteLine(result);
    }
