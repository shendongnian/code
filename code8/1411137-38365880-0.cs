    private void HandleOnNext(int i)
    {
        var isEven = i % 2 == 0
        var temp = new { IsEven = isEven , Version = Interlocked.Increment(ref version) };
        Console.WriteLine($"Time {temp .Version} : {temp .IsEven}");
    }
