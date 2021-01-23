    public async Task DoWorkAsync(string id)
    {            
      var items = GetItems(id);  //takes time
      if (items == null)
        return;
      var tasks = items.Select(item => ProcessAsync(item));
      await Task.WhenAll(tasks);         
    }
    private async Task ProcessAsync(T item)
    {
      await DoSomethingAsync(item);
      await DoWorkAsync(item.subItemId);
    }
