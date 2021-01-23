    int m = 0;
    int n = 0;
    while ((m < names1.Count) && (n < names1.Count))
    {
        int comparison = String.Compare(names1[m], names2[n]);
        if (comparison < 0) // names1[m] is before names2[n]
        {
            names3.Add(names1[m]);
            m = m + 1;
        }
        else if (comparison > 1) //names2[n] is before names1[m]
        {
            names3.Add(names2[n]);
            n = n + 1;
        }
        else //names1[m] is equal to names2[n], only add one.
        {
            names3.Add(names1[m]);
            m = m + 1;
            n = n + 1;
        }
    }
    //either names1 or names2 ran out of entries. fill names3 with whatever is left
    while (m < names1.Count)
    {
        names3.Add(names1[m]);
        m = m + 1;
    }
    while (n < names2.Count)
    {
        names3.Add(names2[n]);
        n = n + 1;
    }
