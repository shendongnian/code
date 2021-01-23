    private async void btnSlowPoke_Click(object sender, EventArgs e)
    {
        await DoItAsync();
    }
    
    private async Task<int> SomeLongJobAsync()
    {
    	Console.WriteLine("Start SomeLongJobAsync, threadId = " + Thread.CurrentThread.ManagedThreadId);
        for (int x = 0; x < 9; x++)
        {
            //ponder my existence for one second
            await Task.Delay(1000);
    		
    		Console.WriteLine("Continue SomeLongJobAsync, threadId = " + Thread.CurrentThread.ManagedThreadId);
        }
    	
        return 42;
    }
    
    public async Task<int> DoItAsync()
    {	
        Console.WriteLine("She'll be coming round the mountain, threadId = " + Thread.CurrentThread.ManagedThreadId);
        Task<int> t = SomeLongJobAsync();  //<--On what thread does this execute?
        Console.WriteLine(" when she comes., threadId = " + Thread.CurrentThread.ManagedThreadId);
        return await t;
    }
    
    void Main()
    {
    	btnSlowPoke_Click(null, null);
    	Console.ReadLine();
    }
