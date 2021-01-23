    int i = 0;
    // Cast OrderedDictionary to IEnumarable<DictionaryEntry> to get an array with the keys
    object[] keys = pickersToTicketMap.Cast<DictionaryEntry>().Select(x=>x.Key).ToArray();
    // iterate over all keys (sorted)
    foreach (object key in keys)
    {
        // set the value of key to element i % pickerPool.Count
        // i % pickerPool.Count will return for Count = 2
        // 0, 1, 0, 1, 0, ...
        pickersToTicketMap[key] = pickersPool.Cast<DictionaryEntry>()
            .ElementAt(i % pickersPool.Count).Value;
        i++;
    }
