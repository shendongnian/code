    public void threadtest()
    {
        var status = "";
        while (loop)
        {
            regularSW.Start();
            Thread.Sleep(5000);
            regularSW.Stop();
            status = "Sleep in: " + regularSW.Elapsed + Environment.NewLine;
        }
    }
