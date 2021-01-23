    class ParamsArrayKeeper
    {
      readonly HashSet<object[]> knownArrays = new HashSet<object[]>(); // reference-equals semantics
      public void NewCall(params object[] arr)
      {
        var isNew = knownArrays.Add(arr);
        Console.WriteLine("Was this params array seen before: " + !isNew);
        Console.WriteLine("Number of instances now kept: " + knownArrays.Count);
      }
    }
