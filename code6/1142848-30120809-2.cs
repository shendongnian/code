    private class DotMap
    {
      //ints because we can't use interlocked with bools
      private int[][] _map = new int[50][];
      public DotMap()
      {
        for(var i = 0; i != 50; ++i)
          _map[i] = new int[50];
      }
      public bool SetIfFalse(int x, int y)
      {
        return Interlocked.CompareExchange(ref _map[x][y], 1, 0) == 0;
      }
    }
