    private readonly ManualResetEventSlim myEvent;
    public User(IFBGraphUser user)
    {
        myEvent = new ManualResetEventSlim();
        id = user.GetId();
        name = user.GetName();
        GetEmail();
        myEvent.Wait();
    }
    
    private void ConnectionReturn(FBRequestConnection connection, NSObject result, NSError error)
    {
        var me = (FBGraphObject)result;
        Console.WriteLine("this is a test");
        this.email = me["email"].ToString();
        myEvent.Set();
    }
