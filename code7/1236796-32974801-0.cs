    Process[] oskProcessArray = Process.GetProcessesByName("TabTip");
    foreach (Process onscreenProcess in oskProcessArray)
    {
        Application.DoEvents();
        onscreenProcess.CloseMainWindow();
        Application.DoEvents();
        Thread.Sleep(1500);
        onscreenProcess.Kill();
    }
