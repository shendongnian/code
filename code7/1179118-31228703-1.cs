    if (au3.WinExists(processName, "") == 0)
    {
        int processId = au3.Run(@"C:\Program Files (x86)\Paint.exe", "", au3.SW_SHOW);
        BringToFront(processId);
        Thread.Sleep(10000);
        au3.MouseClick("LEFT", 358, 913, 1, -1);
    }
    else
    {
        int processId = au3.Run(@"C:\Program Files (x86)\Paint.exe", "", au3.SW_SHOW);
        BringToFront(processId);
        Thread.Sleep(10000);
        au3.MouseClick("LEFT", 358, 913, 1, -1);
    }
