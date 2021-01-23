    public async Task ShowHierarchy(IHierarchyFilterStrategy topHierarchyStrategy, IHierarchyFilterStrategy bottomHierarchyStrategy)
    {
      ...
      var topListTask = Task.Factory.StartNew(() =>
      {
        topHierarchyStrategy != null ? topHierarchyStrategy.RetrieveHierarchy().ToList() : null;
      });
       var bottomListTask = Task.Factory.StartNew(() =>
      {
        bottomList = bottomHierarchyStrategy != null
                   ? bottomHierarchyStrategy.RetrieveHierarchy().ToList()
                   : null;
      });
      await Task.WhenAll(topListTask, bottomListTask);
      //do things with topList, bottomList - they'll be ready at this point
    }
