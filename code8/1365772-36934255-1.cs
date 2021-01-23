    async public string Count(Progress<int> progress)
    {
     int x = 0;
    
        for(x; x<100000; x++)
        {
            await Task.Delay(1);
            progress.OnReport(x);
        }
    
        return "I'm done";
    }
