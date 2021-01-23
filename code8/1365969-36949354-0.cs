    // Getting dictionaries from coreList
    var dictsInCoreList =
        coreList
            .Values
            .Where(value => value is IEnumerable && value.GetType().IsGenericType)
            .SelectMany(value => value as List<object>)
            .Cast<Dictionary<string, object>>()
            .ToList();
    // Generate the result
    ergebnisListe =
        reducedList
            .Select(reducedListItem =>
                {
                    var tempList =
                        new List<string>()
                        {
                            String.IsNullOrEmpty(reducedListItem.Value)
                                ? "!Überschrift_FEHLER"
                                : reducedListItem.Value
                        };
                    tempList.AddRange(
                        dictsInCoreList
                            .Where(dict => dict.ContainsKey(reducedListItem.Key))
                            .Select(dict => dict[reducedListItem.Key]?.ToString() ?? "ERROR")
                    );
                    return new KeyValuePair<string, object>(reducedListItem.Key, tempList);
                }
            )
            .ToList();
