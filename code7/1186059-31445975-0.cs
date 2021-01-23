    bool onetaskCompleted= false;
    private readonly Object obj = new Object();
    
    private async Task<List<PingReply>> PingAsync()
    {
       Ping pingSender = new Ping();
       var tasks = theListOfIPs.Select(ip => pingSender.SendPingAsyn(ip,2000));
       List<Task> continuetask = new List<Task>();
       foreach(Task t in taks)
       {
         continuetask.Add(t.ContinueWith(Action));
       }
    
       var results = await Task.WhenAll(continuetask);
    
       return results.ToList();
    }
    
    private void ContinuationAction()
    {
         lock(obj)
         {
           if(!onetaskCompleted) 
              onetaskCompleted = true;
         }
         if(!onetaskCompleted)
         {
           //execute code 
         }
    }
