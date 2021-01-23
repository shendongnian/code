        foreach (KeyValuePair<string, List<string>> entry in st)
        {
           Console.WriteLine(entry.Key);
           foreach (string s in entry.Value)
           {
               Console.WriteLine(s);
           }
        }
