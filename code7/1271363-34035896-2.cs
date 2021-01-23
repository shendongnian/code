    Dictionary<string, int> stringCount = new Dictionary<string, int>();
    foreach (string S in input) 
    {
        if (stringCount.ContainsKey(S))
        {
            stringCount[S]++;
        }
        else
        {
            stringCount.Add(S, 1);
        }       
    }
    var output = stringCount.Where(x => x.Value == 1).ToList();
