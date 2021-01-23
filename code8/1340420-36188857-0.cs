    private IEnumerable<string> getnums(string num)
    {
        for (int i = 0; i < num.Length - 3; i++)
        {
            yield return num.Substring(i, 4);
        }
    }
    
    private IEnumerable<string> DoIt(string num)
    {
        var data = "2345678901";
        var res = Regex.Matches(data, @"(?=(\d{4}))")
                    .Cast<Match>()
                    .Select(p => p.Groups[1].Value)
                    .ToList();
        return (IEnumerable<string>)res;
     
    }
