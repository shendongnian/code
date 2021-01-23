    private void Execute()
    {
        List<Action> actions = new List<Action>();
    
        for (int i = 0; i < 5; i++)
        {
            actions.Add(() => DoSomething(i));
        }
    
        Parallel.Invoke(actions.ToArray());
    }
    
    private void DoSomething(int value)
    {
        Console.WriteLine("Did something #" + value);
    }
