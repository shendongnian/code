    public override T Add(T item)
    {
        item.Id = IdentityCounter++; // Or use Interlocked.Increment to support multithreading
        _data.Add(item);
        return item;
    }
