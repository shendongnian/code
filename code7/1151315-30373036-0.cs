    private readonly ConcurrentDictionary<string, byte> _list = new ConcurrentDictionary<string, byte>();
    private void Foo(object state)
    {
      // looong operation
      this._list.TryAdd(yourItemKey, 0);
    }
    public void Bar()
    {
      // this is how to query the content
      this._list.Keys...;
    }
