    static void DrawX(int spaceCount, int xCount)
    {
      Console.Write(
        String.Join("",
          Enumerable.Repeat(" ", spaceCount)
          .Concat(Enumerable.Repeat("x", xCount))));
    }
