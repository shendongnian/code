    public void MethodA(object paramsThing)
    {
        var tuple = (Tuple<string, string>)paramsThing;
        var par1 = tuple.Item1;
        var par2 = tuple.Item2;
        // etc.
    }
    
    ...
    
    var workerThread = new Thread(new ParameterizedThreadStart(obj.MethodA));
    workerThread.Start(Tuple.Create("book",5));
