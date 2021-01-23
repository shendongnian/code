    var dictionariesMerged = ticketToPickerMapForVerifiedTab.Cast<DictionaryEntry>()
        .Union(ticketToPickerMapForHVTab.Cast<DictionaryEntry>())
        .Union(ticketToPickerMapForKPTab.Cast<DictionaryEntry>());
    var dictionary = new OrderedDictionary();
    foreach (DictionaryEntry tuple in dictionariesMerged)
        dictionary.Add(tuple.Key, tuple.Value);
