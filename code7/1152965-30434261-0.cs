    using (ServiceHost host = new ServiceHost(typeof(SimpleService.SimpleS­ervice)))
    { 
    ServiceThrottlingBehavior throttlingBehavior = new ServiceThrottlingBehavior { MaxConcurrentCalls = 3, MaxConcurrentInstances = 3, MaxConcurrentSessions = 100 }; 
    host.Description.Behaviors.Add(throttlin­gBehavior); 
    host.Open(); 
    Console.WriteLine("Host started @ " + DateTime.Now.ToString()); 
    Console.ReadLine();
    }
