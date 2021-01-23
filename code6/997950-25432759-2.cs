    ConcurrentBag allItems;
    ConcurrentBag itemsToProcess = new ConcurrentBag(initial);
    // As long as it has an item...
    while(itemsToProcess.TryPeek())
    {
      var tasksCurrentlyProcessing;
      // Process all the items
      while(itemsToProcess.TryTake())
      {
        tasksCurrentlyProcessing = item.GetChildren();
      }
      Task.WaitAll(tasksCurrentlyProcessing);
    }
    public void Task GetChildren()
    {
      // get children, add to allItems and itemsToProcess
    }
