    public static void AddOrUpdate(this ConcurrentDictionary<int, Node> @this, Node newNode)
    {
      @this.AddOrUpdate((int)newNode.Id, newNode, (key, val) => 
        {
          val.Update(newNode);
          return val;
        });
    }
