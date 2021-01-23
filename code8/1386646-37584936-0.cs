    public class BaseRepository<T> where T : BaseEntityWithId, new()
    {
        //Represent the context of the database.
        public DbContext myContext { get; set; }
        //Represent a virtual table of the database.
        protected IDbSet<T> DbSet { get; set; }
        //Represents base constructor of the base repository.
        public BaseRepository()
        {
            this.myContext = new Context();
            this.DbSet = this.Context.Set<T>();
        }
        public IObjectContextAdapter GetObjectContextAdapter()
        {
            return (IObjectContextAdapter)this.Context;
        }
        public virtual void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
    }
