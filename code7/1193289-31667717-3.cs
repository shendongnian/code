    public event Action<string> onStatusChange;
    public void threadtest()
    {
        var status = "";
        while (loop)
        {
            regularSW.Start();
            Thread.Sleep(5000);
            regularSW.Stop();
            if(null != onStatusChange)
            {
                 onStatusChange("Sleep in: " + regularSW.Elapsed + Environment.NewLine);
            }            
        }
    }
