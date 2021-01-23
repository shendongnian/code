    class Foo
    {
      private int[,] data;
      private readonly Indexer first;
      private readonly Indexer second;
        
      public Foo()
      {
        first = new Indexer(0, data);
        second = new Indexer(1, data);
      }
            
      public Indexer First
      {
        get{ return first;}
      }
            
      public Indexer Second
      {
        get{ return second;}
      }
    }
