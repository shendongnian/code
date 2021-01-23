    public Dictionary<string, List<object>> BlaBlaMethod()
    {
        foreach (var reValues in _registeredValues)
        {
            List<object> list;
            if(!_collection.TryGetValue(reValues.Value2, out list))
            {
                //The key was not there, add a new empty list to the dictionary.
                list = new List<object>();
                _collection.Add(reValues.Value2, list);
            }
            //Now, if we are adding or updating, we just need to add on to our list.
            list.Add(reValues.Value3);
        }
    }
