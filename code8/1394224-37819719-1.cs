        public Dictionary<string,Foo> GetFoo(IEnumerable<Bar> bar)
        {
            var query = from x in bar       
                        select new Foo()
                        {
                            x.foo,
                            x.bar
                        };
            return query.ToDictionary(f => f.bar, f => f));
        }
