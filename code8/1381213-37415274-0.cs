    var maxNumber = myTestList.SelectMany(x => getAllNumnbersFromString(x.Name)).DefaultIfEmpty(0).Max();
    
    static List<int> getAllNumnbersFromString(string str)
    {
        List<int> results = new List<int>();
    
        var matchesCollection = Regex.Matches(str, "[0-9]+");
    
        foreach (var numberMatch in matchesCollection)
        {
            results.Add(Convert.ToInt32(numberMatch.ToString()));
        }
    
        return results;
    }
