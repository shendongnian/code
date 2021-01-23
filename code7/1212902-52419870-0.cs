    System.Timers.Timer timer = new System.Timers.Timer();
    timer.Elapsed += new System.Timers.ElapsedEventHandler((object sender, System.Timers.ElapsedEventArgs e) => 
    {
        string IPAddr = null;
        if (axCZKEM1.GetDeviceIP(iMachineNumber, IPAddr))
        {
            LogHelper.Log(LogLevel.Debug, "device " + IPAddr + ":" + port + " connect status is ok.");
        }
    });
    timer.Interval = 600000;// 10 minutes
    timer.Enabled = true;
