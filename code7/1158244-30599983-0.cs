    string GetEqualName(IEnumerable<string> strList)
    {
        int limit = strList.Min(s => s.Length);
    
        int i = 0;
        for (; i < limit; i++)
        {
            if (strList.Select(s => s.Substring(0,i+1)).Distinct().Count() > 1)
            {
                break;
            }
        }
        return strList.First().Substring(0, i).Trim();
    }
