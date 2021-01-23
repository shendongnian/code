        // Initialize dependency to data entities
        private Entities _dataContext;
        public ClassName()
        {
            _dataContext = new Entities();
        }
        public IQueryable<EntityName> MethodName(string filter)
        {
            // Initialize 
            var records = _dataContext.Entity
                     // Constrain your results
                     .Where(
                             x => filter == null
                             || x.Property1.Contains(filter)
                           );
            return records;
        }
