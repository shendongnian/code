        public Repository() : this( ... ) { ... }
        // if need to make public, make sure that the dependency injection container
        // will choose the parameterless constructor;
        // Unity has had issues with that by default
        protected Repository(DbContext context) : base() { ... }
