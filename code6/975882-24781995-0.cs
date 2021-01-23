    var sta = new StaTaskScheduler(numberOfThreads:1);
    
    var comObjects = new { Obj = (ComObject)null };
    Task.Factory.StartNew(() =>
    {
        // create COM object
        comObjects.Obj = (ComObject)Activator.CreateInstance(
            Type.GetTypeFromProgID("Client.ProgID"));
    }, CancellationToken.None, TaskCreationOptions.None, sta);
    //...
    for(int i=0; i<10; i++)
    {
        var result = await Task.Factory.StartNew(() =>
        {
            // use COM object
            return comObjects.Obj.Method();    
        }, CancellationToken.None, TaskCreationOptions.None, sta);
    }
