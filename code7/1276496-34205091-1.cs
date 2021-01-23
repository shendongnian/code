        var x = new Tuple<int,int>[3] { Tuple.Create(0,0), Tuple.Create(0,0), Tuple.Create(0,0) };
        dotMemory.Check(memory =>
        {
          var objectSet = memory.GetObjects(where => where.Type.Is<Tuple<int, int>[]>())
                                .GetExclusivelyRetainedObjects();
          Console.WriteLine(objectSet);
        });
        GC.KeepAlive(x);
