    static void Main(string[] args)
    {
        List<string> strList = new List<string>() { "Value99", "46Text" };
        List<int> resultList = new List<int>();
        
        foreach (var str in strList)
        {
            char[] resultString = Regex.Match(str, @"\d+").Value.ToCharArray();
            int maxInt = resultString.Select(s => Int32.Parse(s.ToString())).Max();
            resultList.Add(maxInt);
        }
    } 
