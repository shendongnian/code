    static bool cancelwork1=false;
    private async Task DoSomeInfiniteWork1()
    {
    log();
        while (true)
        {
            //break logic to exit the loop if required
            if(cancelwork1)
            break;
           
            alive(); // this sends an http request to my server
            Task.Delay(5000); // Replace Thread.Sleep with Task.Delay
        }
    }
    
