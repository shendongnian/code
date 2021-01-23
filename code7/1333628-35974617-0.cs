        [ODataRoute("foo")]
        public List<Foo> GetFoo(ODataQueryOptions<Foo> queryOptions)
        {
            var queryAllFoo = _myQueryProvider.QueryAll<Foo>();
            var modifiedQuery = queryOptions.ApplyTo(queryAllFoo);
            return modifiedQuery.ToList();
        }
