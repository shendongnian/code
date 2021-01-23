    private Object thisLock = new Object();
    public void CallBack(object sender, CallBackEventArgs e)
    {
        Debug.WriteLine("- callback");
        lock(thisLock )
        {            
            foreach(var name in e.ResultCollection)
            {
                dict.Add(name, sender as MyService);
            }
        }
    }
