    public delegate long AtomicReadDelegate<T>(ref T instance);
    
    public static AtomicReadDelegate<T> AtomicRead<T>(string name)
    {
      var dm = new DynamicMethod(typeof(T).Name + "``" + name + "``AtomicRead", typeof(long), 
                                 new [] { typeof(T).MakeByRefType() }, true);
      
      var il = dm.GetILGenerator();
      
      il.Emit(OpCodes.Ldarg_0);
      il.Emit(OpCodes.Ldflda, typeof(T).GetField(name));
      il.Emit(OpCodes.Call, 
         typeof(Interlocked).GetMethod("Read", new [] { typeof(long).MakeByRefType() }));
    
      il.Emit(OpCodes.Ret);
     
      return (AtomicReadDelegate<T>)dm.CreateDelegate(typeof(AtomicReadDelegate<T>));
    }
    private readonly AtomicReadDelegate<Counters>[] _allTheReads = 
      new []
      {
        AtomicRead<Counters>("a"),
        AtomicRead<Counters>("b"),
        AtomicRead<Counters>("c")
      };
    public static void SomeTest(ref Counters counters)
    {
      foreach (var fieldRead in _allTheReads)
      {
        var value = fieldRead(ref counters);
        Console.WriteLine(value);
      }
    }
