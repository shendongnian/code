    var xyz = new Xyz();
    try
    {
        var someValue = xyz.DoSomething();
    }
    catch(Exception e)
    {
        //xyz is still visible here.
    }
