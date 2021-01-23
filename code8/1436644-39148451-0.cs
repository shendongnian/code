    public static Tuple<int, string> PrettyDo(MyTask task)
    {
        Check(task);
        //...
        return Tuple.Create(7, "Done.");
    }
    static void Main(string[] args)
    {
        var task = new MyTask("Add multiple return values");
    
        var result = PrettyDo(task); 
        var err = result.Item1;
        var response = result.Item2;
    }
