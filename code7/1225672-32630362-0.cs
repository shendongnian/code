    Private  Dictionary<string,int> CreateDictionary(log logInstance)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int entryIdex = 0; entryIdex < logInstance.logentry.Count(); entryIdex++)
            {
                logLogentry entry = logInstance.logentry[entryIdex];
                for (int pathIdex = 0; pathIdex < entry.paths.Count(); pathIdex++)
                {
                    logLogentryPath path = entry.paths[pathIdex];
                    string filePath = path.Value;
                    if (filePath.Length > 63)
                    {
                        string cutPath = filePath.Substring(63);
                        if (dictionary.ContainsKey(cutPath))
                        {
                            dictionary[cutPath]++;
                        }
                        else
                        {
                            dictionary.Add(cutPath, 1);
                        }
                    }
                }
            }
            return dictionary;
        }
