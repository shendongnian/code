    foreach(item in array)
    {
        S value;
        // This is an O(1) operation.
        if(dictionary.TryGetValue(item.ToLowerInvariant(), out value)
        {
            // The TryGetValue returns true if the an item 
            // in the dictionary found with the specified key, item
            // in our case. Otherwise, it returns false.
        }
    }
