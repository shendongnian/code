    // You can try timing this program with the default GetHashCode:
    //var dict = new Dictionary<Guid, object>();
    var dict = new Dictionary<Guid, object>(ReverseGuidEqualityComparer.Default);
    var hs1 = new HashSet<int>();
    var hs2 = new HashSet<int>();
    {
        var guid = Guid.NewGuid();
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 1500000; i++)
        {
            hs1.Add(ReverseGuidEqualityComparer.Default.GetHashCode(guid));
            hs2.Add(guid.GetHashCode());
            dict.Add(guid, new object());
            var bytes = guid.ToByteArray();
            Increment(bytes);
            guid = new Guid(bytes);
        }
        sw.Stop();
        Console.WriteLine("Milliseconds: {0}", sw.ElapsedMilliseconds);
    }
    Console.WriteLine("ReverseGuidEqualityComparer distinct hashes: {0}", hs1.Count);
    Console.WriteLine("Guid.GetHashCode() distinct hashes: {0}", hs2.Count);
