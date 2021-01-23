    private Object thisLock = new Object();
    public void CallBack(object sender, CallBackEventArgs e)
    {
        lock(thisLock )
        {
            Debug.WriteLine("- callback");
            foreach(var name in e.ResultCollection)
            {
                dict.Add(name, sender as MyService);
            }
        }
    }
