    public async Task DoWorkAsync(string id)
    {            
      var items = GetItems(id);  //takes time
      if (items == null)
        return;
      var tasks = items.Select(async item => 
      { 
        await DoSomethingAsync(item);
        await DoWorkAsync(item.subItemId);
      });      
      await Task.WhenAll(tasks);         
    }
