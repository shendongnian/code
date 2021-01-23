    var loops = Enumerable.Range(1, 3).Select(i =>
       {
           foreach (var s in strings)
           {
               Debug.WriteLine(s);
           }
           Task.FromResult(true);
       });
    Task.WhenAll(loops).Wait();
