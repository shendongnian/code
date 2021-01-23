    > Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    .             var l = Enumerable.Repeat(123, 10000000).ToList();
    .             Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    .             System.GC.Collect();
    .             Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    140423168
    270663680
    207835136
    >             Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    .             System.GC.Collect();
    .             Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    207761408
    207761408
    > Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    .             var p1 = l;
    207831040
    > Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    207851520
    > var p2 = l;
    .             Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    .             var p3 = l;
    .             Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    208273408
    208273408
    > Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    .             l = null;
    .             System.GC.Collect();
    .             Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    .             p1 = null;
    .             System.GC.Collect();
    .             Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    .             p2 = null;
    .             System.GC.Collect();
    .             Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    .             p3 = null;
    .             System.GC.Collect();
    .             Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
    208314368
    208314368
    208314368
    208314368
    141033472
