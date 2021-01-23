    private void button1_Click(object sender, EventArgs e)
    {
        Process p = Process.Start("<your exe name>");
        p.WaitForInputIdle();
        while (p.MainWindowHandle == IntPtr.Zero)
        {
           Thread.Sleep(100); // Don't hog the CPU
           p.Refresh(); // You need this since `MainWindowHandle` is cached
        }
        SetParent(p.MainWindowHandle, Panel_1.Handle);
    }
