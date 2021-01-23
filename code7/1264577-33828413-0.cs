    void A()
    {
      Debug.WriteLine("pre B");
      B();
      Debug.WriteLine("post B");
    }
    void B()
    {
      Debug.WriteLine("inside B");
      Thread.Sleep(1000);
      Debug.WriteLine("still inside B");
    }
