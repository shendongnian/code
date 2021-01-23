    public Task ShowHierarchy(IHierarchyFilterStrategy topHierarchyStrategy, IHierarchyFilterStrategy bottomHierarchyStrategy)
            {
                IEnumerable<IHierarchyNodeViewModel> topList = null;
                IEnumerable<IHierarchyNodeViewModel> bottomList = null;
                var context = TaskScheduler.FromCurrentSynchronizationContext();
                var options = TaskCreationOptions.LongRunning
        | TaskCreationOptions.AttachedToParent;
                var task = Task.Factory.StartNew(() =>
                {
                    topList = topHierarchyStrategy != null ? topHierarchyStrategy.RetrieveHierarchy().ToList() : null;
                    bottomList = bottomHierarchyStrategy != null
                        ? bottomHierarchyStrategy.RetrieveHierarchy().ToList()
                        : null;
                },CancellationToken.None,options, TaskScheduler.Default);
    
                return task.ContinueWith((antecedent) =>
                {
                    View.SetAvailableNodes(topList, bottomList);
                }, context);
            }
