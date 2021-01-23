    public IEnumerable<string> ReturnMyStrings(string str)
    {
        int[] br = { 15, 18, 33, 61, 81, 89, 93, 94, 102, 110, 111, 114, 118 }; 
        return br.Select((x, index) => 
           str.Substring(br.ElementAtOrDefault(index - 1), x - br.ElementAtOrDefault(index - 1)))
           .ToList();
    }
