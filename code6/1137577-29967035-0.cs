    public static void PerformTask()
    {
        Console.WriteLine("Starting Task {0}", Task.CurrentId);
        //string input = null;
        //string output = input.ToUpper();
        throw new Exception("Throwing exception in task " + Task.CurrentId);
    }
