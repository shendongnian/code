    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);
    private void debugButton_Click(object sender, EventArgs e)
        {
            //GetProcess by Class
            IntPtr rightNowHandle = FindWindow("WindowsForms10.Window.8.app.0.24dc298_r17_ad2", null);
            //Get Handle by Process
            Process proc = Process.GetProcessesByName("RightNow.CX")[0];
            IntPtr ptrFF = proc.MainWindowHandle;
            //Get a handle for the Calculator Application main window
            if (rightNowHandle == IntPtr.Zero)
            {
               MessageBox.Show("Could Not Find Right Now");
                return;
            }
            SetForegroundWindow(ptrFF); //Activate Handle By Process
            //SetForegroundWindow(rightNowHandle); //Activate Handle By Class
            InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.VK_A);
        }
