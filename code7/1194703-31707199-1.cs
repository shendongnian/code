    public class FooService : IFooService
    {
        private DbContext db;
        public FooService(DbContext db)
        {
            this.db = db;
        }
        public Foo CalculateFoo(int id)
        {
            var foo = this.db.Foo.First(f => f.id == id);
            // do stuff
            return foo;
        }
    }
