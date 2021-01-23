    List<string> intersection = new List<string>();
    
    foreach (string a in GetaList())
    {
        foreach (string b in GetbList())
        {
            if (a.Equals(b))
            {
                intersection.Add(a);
            }
        }
    }
