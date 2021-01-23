    public async Task ReturnASAP()
    {
        var task = LongRunningTask();	//1
		DoSomeLogic()	//3
		
        await task;	//4
		
		//Do some more logic here //6
    }
    private async Task LongRunningTask()
    {
        await Task.Delay(2000); //2
		System.Console.WriteLine("Long running task is done! Huray!"); //5
    }
