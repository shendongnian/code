    public override void Run()
    {
       try
       {
          Trace.WriteLine("WorkerRole entrypoint called", "Information");
          while (true)
          {
             // Add code here that runs in the role instance
          }
          
       }
       catch (Exception e)
       {
          Trace.WriteLine("Exception during Run: " + e.ToString());
          // Take other action as needed.
       }
    }
