    public interface DbEntity
    {
        int Id { get; set; }
    }
    public class MockDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T> where T : DbEntity
