    var contractDictionary = new DictionaryDictionary<int, ContractData>();
    
    ...
       if (!contractDictionary.ContainsKey(sales.ContractId))
       {
          contractDictionary.Add(sales.ContractId, ContractData.Create(sales.ContractId, sales.Name, 0));
       }
    foreach (var item in contractDictionary.Values)
    {
       emailBody += string.Format("Contract {0} total sales cost: {1}", item.Name, item.Amount);
    } 
