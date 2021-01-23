    A SortEverything(A input)
    {
       return new A {
          BList = input.BList.Select(b =>
              new B {
                 OrderId = b.OrderId,
                 CList = input.CList.OrderBy(c => c.OrderId);
              }).OrderBy(b => b.OrderId);
       };
    }
