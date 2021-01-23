    var oldGrouped = oldList.ToDictionary(x => x.Fruit, x => x.Qty);
    var newGrouped = newList.ToDictionary(x => x.Fruit, x => x.Qty);
    var result = new List<FruitSummary>();
    
    foreach(var oldItem in oldGrouped)
    {
        var summary = new FruitSummary { OldFruit = oldItem.Key, OldQty = oldItem.Value };
        if(newGrouped.TryGetValue(oldItem.Key, out int newQuantity) && newQuantity != 0)
        {
            summary.NewFruit = oldItem.Key;
            summary.NewQty = newQuantity;
        }
        summary.Diff = oldItem.Value - newQuantity;
        newGrouped.Remove(oldItem.Key);
        result.Add(summary);
    }
    foreach(var newItem in newGrouped)
    {
        result.Add(new FruitSummary { Diff = -newItem.Value,
                                      NewFruit = newItem.Key,
                                      NewQty = newItem.Value });
    }
