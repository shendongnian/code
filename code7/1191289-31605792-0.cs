    Dictionary<string, string> newItem = new Dictionary<string, string>();
    newItem.Add("name", item.Name);
    newItem.Add("value", item.Value);
  
    if (!control.ContainsKey(item.Name))
    {
       control.Add(item.Name);
       items.Add(newItem);
    }
