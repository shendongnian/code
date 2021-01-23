    [DllImport("user32.dll", SetLastError = true)]
    static extern bool MoveWindow(IntPtr hWnd, 
        int X, int Y, int nWidth, int nHeight, bool bRepaint);
    private void FormMain_Resize(object sender, EventArgs e)
    {
        if (!ShowInTaskbar && WindowState == FormWindowState.Minimized) {
            Hide();
            //Move the invisible minimized window near the tray notification area
            if (!MoveWindow(Handle, Screen.PrimaryScreen.WorkingArea.Left
                    + Screen.PrimaryScreen.WorkingArea.Width - Width - 100,
                    Top, Width, Height, false))
                throw new Win32Exception();
        }
    }
    private void notifyIcon_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            if (WindowState == FormWindowState.Minimized || !timer.Enabled) {
                Show();
                WindowState = FormWindowState.Normal;
                Activate();
            }
            else {
                WindowState = FormWindowState.Minimized;
                //FormMain_Resize will be called after this
            }
    }
    private void FormMain_Deactivate(object sender, EventArgs e)
    {
        timer.Start();
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        timer.Stop();
    }
    //other free goodies not mentioned before...
    private void taskbarToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowInTaskbar = !ShowInTaskbar;
        taskbarToolStripMenuItem.Checked = ShowInTaskbar;
    }
    private void priorityToolStripMenuItem_Click(object sender, EventArgs e)
    {
        //Set the process priority from ToolStripMenuItem.Tag
        //Normal = 32, Idle = 64, High = 128, BelowNormal = 16384, AboveNormal = 32768
        Process.GetCurrentProcess().PriorityClass
            = (ProcessPriorityClass)int.Parse((sender as ToolStripMenuItem).Tag.ToString());
        foreach (ToolStripMenuItem item in contextMenuStrip.Items)
            if (item.Tag != null)
                item.Checked = item.Equals(sender);
    }
    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }
