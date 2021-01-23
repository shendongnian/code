        [EnableQuery(EnsureStableOrdering = false)]
        public IEnumerable<SomeType> Get()
        {
            return GetSomeTypes().Take(2);    
        }
