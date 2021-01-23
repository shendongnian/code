    int seed = Environment.TickCount;
    var random = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));
    var tbls = new ConcurrentBag<Tbl>();
    Parallel.For(0, 1500, (i) => {
        tbls.Add(new Tbl()
        {
            Name = "User" + i + 1,
            Num = random.Value.Next(10, i + 10) / 10
        });
    });                
    db.Tbls.AddRange(tbls);
