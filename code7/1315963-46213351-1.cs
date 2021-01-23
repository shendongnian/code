    namespace MyProject.Foo.Repositories
    {
        public class FooRepository: IFooRepository
        {
            private class Foo: IFoo
            {
                public string Property1 { get; set; }
                public string Property2 { get; set; }
            }
    
            public IEnumerbale<IFoo> GetFoos()
            {
                IEnumerable<IFoo> foo = _dbConnection.Query<Foo>("My query there");
                return foo;
            }
        }
    }
