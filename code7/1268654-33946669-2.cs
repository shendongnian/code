    Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
    
    int i = -1;
    while (i < lstAccounts.Count - 1)
    {   
        for (int i2 = 0; i2 < lstAgents.Count; i2++)
        {
            i = i + 1;
            string curAccount = lstAccounts[i];
            string curAgent = lstAgents[i2];
            
            if (!results.ContainsKey(curAgent)) results.Add(curAgent, new List<string>());
            results[curAgent].Add(curAccount);
    
            if (i >= lstAccounts.Count - 1) break;
        }
    }
