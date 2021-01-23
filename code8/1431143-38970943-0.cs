    var contractDictionary = new DictionaryDictionary<int, Tuple<string, decimal>>();
    
    public void UpdateSales(SalesTbl sales)
    {
    ...
       if (!contractDictionary.ContainsKey(sales.ContractId))
       {
          contractDictionary.Add(sales.ContractId, Tuple.Create(sales.Name, 0));
       }
    ...
    }
    
    foreach (var item in contractDictionary)
    {
       emailBody += string.Format("Contract {0} total sales cost: {1}", item.Value.Item1, item.Value.Item2);
    }
