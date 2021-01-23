    List<WorkingTransaction> rootParents = new List<WorkingTransaction>();
    foreach (var kvp in workDict)
    {
        WorkingTransaction parent;
        if (workDict.TryGetValue(kvp.Value.Details.ParentReferenceNumber, out parent)
        {
            parent.Children.Add(kvp.Value);
            kvp.Value.HasParent = true;
        }
        else
        {
            rootParents.Add(kvp.Value);
        }
    }
