    foreach(var key in dictionaryA)
    {
        // Check if the key is not contained in the keys collection of dictionaryB.
        // If so, add the corresponding element of the dictionaryA to the dictionaryB. 
        if(!dictionaryB.Keys.Contains(key))
            dictionaryB.Add(key, dictionaryA[key].ToString());
    }
