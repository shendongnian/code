    var differences = new List<string>();
    for (int i = 0; i < original.Count; i++)
    {
        bool found = false;
        for (int j = 0; j < web.Count; j++)
        {
            if (original[i][0] == web[j][0])
            {
                found = true;
            }
        }
    
        if (!found)
        {
            differences.Add(original[i][0]);
        }
    }
