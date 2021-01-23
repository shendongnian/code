    public IEnumerable<xxxx> Get(string Id)
    {        
        //Check if timer exists in
        DeviceContainer.timers.Any(s=>s.Identifier.Equals(Id))
        //Code that turns on the device
        //If not
             //Create new object of timer, assign identifier =Id, 
             //set interval and initialize it. add it to collection as
             DeviceContainer.timers.Add(xxxx);
         // If exists
             //Code to stop the existing timer and start it again.
    }
    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        //code that will turn off the device in DB
    }
