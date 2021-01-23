    private BlockingCollection<MyObj> stack;
    private Task consumer;
    Constructor()
    {
      stack = new BlockingCollection<MyObj>(new ConcurrentStack<MyObj>());
      consumer = Task.Run(() =>
      {
        foreach (var myObj in stack.GetConsumingEnumerable())
        {
          ...
        }
      });
    }
    private void AddToStack(MyObj obj)
    {
      stack.Add(obj);
    }
