    protected override void OnStart(string[] args)
    {    
        Parallel.ForEach(
            machinelist, (list) => 
            {
                var Application = //however you do this...
                Application.Run();
            }
        );
    }
