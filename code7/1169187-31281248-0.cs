    List<IWorkItemData> workitems = new List<IWorkItemData>();
    
    // collect all of the IDs
    var items = Store.Query(query).Cast<WorkItem>().Select(wi = wi.Id).ToArray();
    // then go through the list, get the complete workitem, create the wrapper,
    // and finally add it to the collection
    System.Threading.Tasks.Parallel.For(0, items.Length, i =>
    {
        var workItem = Store.GetWorkItem(items[i]);
        var item = new TFSWorkItemData(workItem);
        workitems.Add(item);
    });
