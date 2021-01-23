        [EnableQuery]
        public SingleResult<FooDto> Get(string key)
        {
            return
                SingleResult.Create(
                    Context.Foos.AsNoTracking().Where(set => set.FooId == key)
                        .Project()
                        .To<FooDto>()
                        .AsQueryable());
        }
