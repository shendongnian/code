        _udaTuple = new ObservableCollection<Tuple<object, object>>();        
        var tempDictionary = new Dictionary<object, object>();
        foreach (var item in Enumerator)
            {
                var modelObject = item as TSM.ModelObject;
                if (modelObject != null)
                {
                    var tempHash = new Hashtable();
                    modelObject.GetAllUserProperties(ref tempHash);
                    foreach (DictionaryEntry dictionaryEntry in tempHash)
                    {
                        if (tempDictionary.ContainsKey(dictionaryEntry.Key))
                        {
                            if (tempDictionary[dictionaryEntry.Key] is string && dictionaryEntry.Value is string)
                            {
                                if ((string)tempDictionary[dictionaryEntry.Key]!=(string)dictionaryEntry.Value)
                                {
                                    tempDictionary[dictionaryEntry.Key] = "Values Do Not Match";
                                }
                            }
                            else if (tempDictionary[dictionaryEntry.Key] is double && dictionaryEntry.Value is double)
                            {
                                if ((double)tempDictionary[dictionaryEntry.Key] != (double)dictionaryEntry.Value)
                                {
                                    tempDictionary[dictionaryEntry.Key] = "Values Do Not Match";
                                }
                            }
                            else if (tempDictionary[dictionaryEntry.Key] is int && dictionaryEntry.Value is int)
                            {
                                if ((int)tempDictionary[dictionaryEntry.Key] != (int)dictionaryEntry.Value)
                                {
                                    tempDictionary[dictionaryEntry.Key] = "Values Do Not Match";
                                }
                            }
                        }
                        else
                        {
                            tempDictionary.Add(dictionaryEntry.Key, dictionaryEntry.Value);
                        }
                    }
                }
            }
            foreach (var item in tempDictionary)
            {
                _udaTuple.Add(new Tuple<object, object>(item.Key, item.Value));
            }
