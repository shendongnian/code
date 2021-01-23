    protected override void OnStart(string[] args)
    {
        Task.Run(async ()=> { while(true) await LunchTasks(); });
    }
    
    private Task LunchTasks()
    {
    	var tasks = machinelist.Select(machinelist=> 
        foreach( var machinelist in machinelist)
        {
    		createComAndMessagePumpThread2 = new Thread(() =>
    		{
    		   // connection with machines code using list
    		   Application.Run();
    		});
            createComAndMessagePumpThread2.SetApartmentState(ApartmentState.STA);
    
            createComAndMessagePumpThread2.Start();
            return Task.Delay(2000);
        }
    }
