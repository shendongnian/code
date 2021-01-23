    var comObjects = new { Obj = (ComObject)null, Obj2 = (AnotherComObject)null };
    //...
    await Task.Factory.StartNew(() =>
    {
        // use COM object
        comObjects.Obj2 = comObjects.Obj.Method();    
    }, CancellationToken.None, TaskCreationOptions.None, sta);
