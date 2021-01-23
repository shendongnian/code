    public IEnumerable<xxxx> Get(string Id)
    {        
        //Check if timer exists in
        if(!DeviceContainer.timers.Any(s=>s.Identifier.Equals(Id)))
        {
             //Create new object of timer, assign identifier =Id, 
             //set interval and initialize it. add it to collection as
             var timer = new DevTimer();
             timer.AutoReset = true;
             timer.Enabled = true;
             timer.Interval = 5000; //miliseconds
             timer.Elapsed += timer_Elapsed;
             timer.IsInUse=true;
             timer.Identifier=Id;             
             DeviceContainer.timers.Add(timer);
             timer.Start();
        }
        else
        {
             //Code to stop the existing timer and start it again.
             var _timer=DeviceContainer.timers.FirstOrDefault(s=>s.Identifier.Equals(Id)) 
                          as DevTimer;
             _timer.Stop();
             _timer.Start();
        }        
    }
    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        //code that will turn off the device in DB
    }
