    var collection = new List<ExpandoObject>();
    
    foreach (var i in items)
                {
                    dynamic a = new ExpandoObject();
                    a.Item = i.item;
                    a.Supplier = 25;
                    collection.Add(a);
                }
