    List<string> names1 = new List<string>();
    List<string> names2 = new List<string>();
    List<string> names3 = new List<string>();
    var included = new HashSet<string>();
    int m = 0;
    int n = 0;
    while ((m < names1.Count) && (n < names1.Count))
    {
        int comparison = String.Compare(names1[m], names2[n]);
        if (comparison < 0)
        {
            if(included.Add(names1[m]))
            {
                names3.Add(names1[m]);
            }
            m = m + 1;
        }
        else if (comparison > 1)
        {
            if (included.Add(names2[n]))
            {
                names3.Add(names2[n]);    
            }
            n = n + 1;
        }
        else
        {
            names3.Add(names1[m]);
            m = m + 1;
            n = n + 1;
        }
    }
    while (m < names1.Count)
    {
        if (included.Add(names1[m]))
        {
            names3.Add(names1[m]);
        }
        m = m + 1;
    }
    while (n < names2.Count)
    {
        if (included.Add(names2[n]))
        {
            names3.Add(names2[n]);
        }
        n = n + 1;
    }
