    var array = collection.Select(() => .....).ToList();
    
    while (index < array.Count())
    {
          int index_dup = index
        this.CurrentDispatcher.Invoke(new Action(() =>
        {
            ...
            object a = array.ElementAt(index_dup)
            ...
        }), DispatcherPriority.Input);
    
        index++;
    }
