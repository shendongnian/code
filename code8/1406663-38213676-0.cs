    foreach ( string pattern in patterns )
    {
        // save the non x indexes
        var indexes = new List<int>(); 
        for (int i = 0; i < pattern.Length; i++)
            if (pattern[i] != 'x')
                indexes.Add(i);
        foreach ( string combination in combinations )
        {
            bool combination_passed = true;
            foreach (int i in indexes)
            {
                if (combination[i] != pattern[i])
                {
                    combination_passed = false;
                    break;
                }
            }
            // ...
        }
    }
