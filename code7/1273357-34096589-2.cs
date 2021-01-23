        foreach (KeyValuePair<string, List<string>> entry in st)
        {
           Console.WriteLine(entry.Key);
           foreach (string s in entry.Values)
           {
              Console.WriteLine(s);
           }
        }
