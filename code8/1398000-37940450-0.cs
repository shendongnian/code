                Dictionary<string, string> _dictKPVtoUpdate = new Dictionary<string, string>();
            OrderedDictionary newValues =new OrderedDictionary();
            OrderedDictionary oldValues = new OrderedDictionary();
            foreach (DictionaryEntry tmpEntry in newValues)
            {
                if (oldValues.Contains(tmpEntry.Key))
                {
                    _dictKPVtoUpdate.Add(tmpEntry.Key.ToString(),tmpEntry.Value.ToString());
                }
            }
