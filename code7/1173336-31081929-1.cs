    //BaseModel is a class that has a key called Id that is of type string
    public class TestBaseClassDbSet<TEntity> : 
        DbSet<TEntity>
        , IQueryable, IEnumerable<TEntity>
        , IDbAsyncEnumerable<TEntity>
        where TEntity : BaseModel
    {
        //....copied all the code from the TestDbSet class that was provided
        //Added the missing functions
        public override TEntity Find(params object[] keyValues)
        {
            var id = (string)keyValues.Single();
            return this.SingleOrDefault(b => b.Id == id);
        }
        public override Task<TEntity> FindAsync(params object[] keyValues)
        {
            var id = (string)keyValues.Single();
            return this.SingleOrDefaultAsync(b => b.Id == id);
        }
    }
