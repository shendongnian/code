      foreach (Hashtable hb in searchList)
            {
                foreach (DictionaryEntry entry in hb)
                {
                    Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
                }
            }
