    using System.Linq;
    ...
    int i = 0;
    // Cast OrderedDictionary to IEnumarable<DictionaryEntry> to be able to use System.Linq
    object[] keys = pickersToTicketMap.Cast<DictionaryEntry>().Select(x=>x.Key).ToArray();
    IEnumerable<DictionaryEntry> pickersPoolEnumerable =  pickersPool.Cast<DictionaryEntry>();
    // iterate over all keys (sorted)
    foreach (object key in keys)
    {
        // Set the value of key to element i % pickerPool.Count
        // i % pickerPool.Count will return for Count = 2
        // 0, 1, 0, 1, 0, ...
        pickersToTicketMap[key] = pickersPoolEnumarable
            .ElementAt(i % pickersPool.Count).Value;
        i++;
    }
