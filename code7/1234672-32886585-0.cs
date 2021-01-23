    Dictionary<string, double> collection = new Dictionary<string, double>();
    collection.Add("A", 1.0);
    collection.Add("B", 2.0);
    
    Dictionary<string, double> collection2 = new Dictionary<string, double>(collection);
    
    foreach (KeyValuePair<string, double> pair in collection)
    {
      double val = 3.0;              
      collection2.Remove(pair.Key);
      collection2.Add(pair.Key, val);
     }
