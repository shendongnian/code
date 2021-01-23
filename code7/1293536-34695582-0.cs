    Task.Factory.StartNew(() => Console.WriteLine(1))
        .ContinueWith(t => Thread.Sleep(1000))
        .ContinueWith(t => Console.WriteLine(2))
        .ContinueWith(t => Thread.Sleep(1000))
        .ContinueWith(t => { throw new Exception("aaaa"); })
        .ContinueWith(t => Console.WriteLine(3));
    Console.ReadLine();
    GC.Collect();
    GC.Collect();
    Console.ReadLine();
