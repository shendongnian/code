    public override T Add(T item)
    {
        item.Id = IdentityCounter++; // Or use Interlocked.Increment to support multithreading
        _data.Add(item);
        return item;
    }
    public class MockDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T> where T : DbEntity
