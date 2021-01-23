    var contractDictionary = new DictionaryDictionary<int, Tuple<string, decimal>>();
    ...    
       if (!contractDictionary.ContainsKey(sales.ContractId))
       {
          contractDictionary.Add(sales.ContractId, Tuple.Create(sales.Name, 0));
       }
    
    foreach (var item in contractDictionary.Values)
    {
       emailBody += string.Format("Contract {0} total sales cost: {1}", item.Item1, item.Item2);
    }
