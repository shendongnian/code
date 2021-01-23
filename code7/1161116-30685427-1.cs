        [EnableQuery]
        public IQueryable<FooDto> Get()
        {
            // Load set into read-only context for performance.
            var sets = Context.Foos.AsNoTracking();
            // AutoMapper will modify the database query to support exposing DTOs
            var setsDtos = sets.Project().To<FooDto>();
            return setsDtos;
        }
