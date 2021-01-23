    static void Main(string[] args)
    {
        ClassOne xx = new ClassOne();
        var v1 = xx.DummyTask();
        var resultV1 = v1.Result; //Forces the execution of v1 by requesting its result.
    }
