    public partial class FooContext : DbContext
    {
        public IQueryable<foo> foo => 
            this.Database.SqlQuery<foo>( "select * from foo" ).AsQueryable();
    }
