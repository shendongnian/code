    public string[] ReturnMyStrings(string str)
    {
        int[] br = { 15, 18, 33, 61, 81, 89, 93, 94, 102, 110, 111, 114, 118 }; 
        return br.Select((x, i) => 
           str.Substring(br.ElementAtOrDefault(i - 1), x - br.ElementAtOrDefault(i - 1)))
           .ToArray();
    }
