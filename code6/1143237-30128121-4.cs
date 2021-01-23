    foreach (var word in document)
    {
        double myValue;
        // See if the value exists in the big directory
        var valueExists = bigDict.TryGetValue(word.Key, out myValue);
        if (valueExists)
        {
            // See if the testing dict has the same key
            if (testing.ContainsKey(word.Key))
            {
                // It does, add the value to the list
                if (word.Value < 2)
                {
                    testing[word.Key].Add(myValue);
                }
            }
            else
            {
                // It doesn't, add the key with the value
                testing.Add(word.Key, new List<double>() { myValue });
            }
        }
    }
