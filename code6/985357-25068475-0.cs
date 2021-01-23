    List<ValuePair> pairs = new List<ValuePair>();
    pairs.Add(new ValuePair("A", "B"));
    pairs.Add(new ValuePair("A", "C"));
    pairs.Add(new ValuePair("B", "C"));
    pairs.Add(new ValuePair("C", "D"));
    
    List<ValuePair> uniquePairs = new List<ValuePair>(); 
    // this list is not really needed if all you care about 
    //   is getting the resulting groups
    
    List<HashSet<string>> sets = new List<HashSet<string>>();
    
    foreach (ValuePair pair in pairs)
    {
        int value1Set = -1;
        int value2Set = -1;
    
        for (int i = 0; i < sets.Count; i++)
        {
            HashSet<string> set = sets[i];
    
            if (set.Contains(pair.value1))
                value1Set = i;
            if (set.Contains(pair.value2))
                value2Set = i;
        }
    
        if (value1Set == -1 && value2Set == -1)
        {
            // we have a new set
            sets.Add(new HashSet<string> {pair.value1, pair.value2});
        }
        else if (value1Set == -1)
        {
            sets[value2Set].Add(pair.value1);
        }
        else if (value2Set == -1)
        {
            sets[value1Set].Add(pair.value2);
        }
        else
        {
            if (value1Set == value2Set)
            {
                // duplicate entry, skip the add
                continue;
            }
    
            // merge the sets at value1Set and value2Set
            foreach (string value in sets[value2Set])
            {
                sets[value1Set].Add(value);
            }
            sets.RemoveAt(value2Set);
        }
    
        uniquePairs.Add(pair);
    }
