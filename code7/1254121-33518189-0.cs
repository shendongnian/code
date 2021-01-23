    int i = 0;
    object[] keys = pickersToTicketMap.Cast<DictionaryEntry>().Select(x=>x.Key).ToArray();
    foreach (object key in keys)
    {
        pickersToTicketMap[key] = pickersPool.Cast<DictionaryEntry>()
            .ElementAt(i % pickersPool.Count).Value;
        i++;
    }
