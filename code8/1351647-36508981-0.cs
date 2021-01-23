    static void Main(string[] args)
    {
        
        var a = ParseFileAndProduceABigTreeObject(args[0]);
        var aWeakReference = new WeakReference(a);
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        Console.WriteLine($"a: {aWeakReference.IsAlive}");
        var b = WalkTheBigTreeObjectAndProduceSomeOtherBigObject(a);
        var bWeakReference = new WeakReference(b);
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        Console.WriteLine($"a: {aWeakReference.IsAlive} b: {bWeakReference.IsAlive}");
        var c = AThirdRoundOfProcessing(b);
        var cWeakReference = new WeakReference(c);
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        Console.WriteLine($"a: {aWeakReference.IsAlive} b: {bWeakReference.IsAlive} c:{cWeakReference.IsAlive}");
        Console.WriteLine(c.ToString());
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        Console.WriteLine($"a: {aWeakReference.IsAlive} b: {bWeakReference.IsAlive} c:{cWeakReference.IsAlive}" );
        Console.ReadLine();
    }
