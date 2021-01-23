    public static int erCount = 9;
    static void Main(string[] args)
    {
        var task = Task.Factory.StartNew(() => 
        { 
            ...do some task
            if(errorfound)
                Interlocked.Increment(ref erCount);
        });
        task.Wait();//Wait for the task to complete
        Console.Writeline(erCount.toString());
    }
