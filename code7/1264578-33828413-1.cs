    async Task A()
    {
      Debug.WriteLine("pre B");
      await B();
      Debug.WriteLine("post B");
    }
    async Task B()
    {
      Debug.WriteLine("inside B");
      await Task.Delay(1000);
      Debug.WriteLine("still inside B");
    }
