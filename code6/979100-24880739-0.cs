    ...
        private readonly List<WorkItem> workItems = new List<WorkItem>();
        // There's no need the property to be virtual 
        public IReadOnlyList<WorkItem> WorkItems {
          get {
            return workItems;
          }
        }
    ...
