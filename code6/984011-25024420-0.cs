    public static async Task CallProc()
    {
        var two = Task.Factory.StartNew(() => SomeSynchronousProcessIDontOwn(5000, "two"));
        var one = Task.Factory.StartNew(() => SomeSynchronousProcessIDontOwn(500, "one"));
        var three = Task.Factory.StartNew(() => SomeSynchronousProcessIDontOwn(1500, "three"));
        // run synchronous tasks
        await Task.WhenAll(one, two, three);
    }
