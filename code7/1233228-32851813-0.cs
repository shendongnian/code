    public IHttpActionResult ChangeVendor(ChangeVendorModel changeModel)
    {        
        var changeCommand = changeModel.MapTo<ChangeVendorCommand>();   
        bus.Send(changeCommand); // start the change processing
        var replyReceived=false;
        bool success = false;
        while(!replyreceived)
        {
            Task vendorChanged = Task.Factory.StartNew(()=> 
                {
                     var reply=bus.Receive<VendorChanged>());
                     if(reply.CorrelationToken==changeCommand.CorrelationToken)
                     {
                          replyReceived=true;
                          success=true;
                     }
                },SomeTimeout);
            Task vendorChangedFailed = Task.Factory.StartNew(()=> 
                {
                     var reply=bus.Receive<VendorChangeFailed>());
                     if(reply.CorrelationToken==changeCommand.CorrelationToken)
                     {
                          replyReceived=true;
                          success=false;
                     }
                },SomeTimeout());
                Task.WaitAny(new Task[]{});
            
        }
        if(success)
        {
            return Ok(); 
        }
        else
        { 
            return ChangeVendorFailed();
        }
    }
