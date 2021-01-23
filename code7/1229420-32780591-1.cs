    public class FooRepository :
        GenericRepository<Foo>, IFooRepository {
    
        public FooRepository(DbContext context) : base(context) {}
    }
