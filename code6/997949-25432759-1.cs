    private void MainFunction(int id)
    {
      var main = await GetItemAsync(id);
      await PopulateChildren(main);
    }
    private async void PopulateChildren(Item parent)
    {
      var children = GetChildren(Item parent);
      foreach(var child in children) 
      { 
        parent.ChildCollection.Add(child); 
        PopulateChildren(child); 
      }
    }
    private IEnumerable<Item> GetChildren(Item parent)
    {
      // I/O code
    }
