    // collect all of the IDs
    var itemIDs = Store.Query(query).Cast<WorkItem>().Select(wi = wi.Id).ToArray();
    IWorkItemData[] workitems = new IWorkItemData[itemIDs.Length];
    // then go through the list, get the complete workitem, create the wrapper,
    // and finally add it to the collection
    System.Threading.Tasks.Parallel.For(0, itemIDs.Length, i =>
    {
        var workItem = Store.GetWorkItem(itemIDs[i]);
        var item = new TFSWorkItemData(workItem);
        workitems[i] = item;
    });
