    private void fuc()
    {
        System.Diagnostics.Process[] procArray;
        procArray = System.Diagnostics.Process.GetProcesses();
        List<KeyValuePair<string, int>> threads = new List<KeyValuePair<string,int>>();
        for (int i = 0; i < procArray.Length; i++)
        {
            var element = new KeyValuePair<string, int>(procArray[i].ProcessName, procArray[i].Threads.Count);
            threads.Add(element);
        }
        threads.Sort(OrderAsc);
    }
    
    static int OrderAsc(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
    {
         return a.Value.CompareTo(b.Value);
    }
