    XDocument doc = XDocument.Load(xml);
    
    var list = doc.Element("inventory").Elements("product");
    var stockDictionary = stockArray.ToDictionary(item => item.Id, item => item.Count);
    foreach (var node in list)
    {
        int newCount;
        if (if(stockDictionary.TryGetValue((int)node.Element("recordNumber"), out newCount)
            node.SetElementValue("stock", newCount);
    }
