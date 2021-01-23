        public Foo FetchSomeData(string query)
        {
            using (var cn = Connection)
            {
                var result = cn.Query(query);
               //do something with result, and return it
               return new Foo(result);
            }
        }
