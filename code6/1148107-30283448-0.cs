    static void Main(string[] args)
    {
        var sch = new ConcurrentExclusiveSchedulerPair().ExclusiveScheduler;
        var tf = new TaskFactory(sch);
        var t = tf.StartNew(() => Run()).Result;
        t.Wait();
    }
    static async Task Run()
    {
        var start = DateTime.UtcNow;
        var t = Task.Delay(1000).ContinueWith(_ =>
        {
            Console.WriteLine("I tried to log after 1 second, ended up logging after {0}", (DateTime.UtcNow - start).TotalSeconds);
        });
        Console.WriteLine("It has not yet been 1 second. I will hog the only thread available to demonstrate how I simulate JS behavior.");
        Thread.Sleep(2000);
        await t;
    }
