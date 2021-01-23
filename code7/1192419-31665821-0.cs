    public sealed class Pool
    {
      private readonly BufferBlock<Resource> _block = new BufferBlock<Resource>();
      public Pool()
      {
        _block.Post(new Resource(this, ...));
        _block.Post(new Resource(this, ...));
      }
      public Resource Allocate()
      {
        return _block.Receive();
      }
      public Task<Resource> AllocateAsync()
      {
        return _block.ReceiveAsync();
      }
      private void Release(Resource resource)
      {
        _block.Post(resource);
      }
      public sealed class Resource : IDisposable
      {
        private readonly Pool _pool;
        public Resource(Pool pool, ...)
        {
          _pool = pool;
          ...
        }
        public void Dispose()
        {
          _pool.Release(this);
        }
      }
    }
