    ...
        private readonly List<WorkItem> workItems = new List<WorkItem>();
        // Usually, there's no need the property to be virtual 
        public virtual IReadOnlyList<WorkItem> WorkItems {
          get {
            return workItems;
          }
        }
    ...
