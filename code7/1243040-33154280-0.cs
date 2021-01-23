    class DictionaryResolver : ValueResolver<int, Dictionary>
    {
        public Dictionary Resolve(int source)
        {
              return ResolveCore(source);
        }
        protected override Dictionary ResolveCore(int source)
        {
            // do something
            return new Dictionary
            {
                Id = source,
                Name = "Name"
            };
        }
    }
