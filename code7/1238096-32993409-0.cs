    using Microsoft.Win32;
     
     public Form1()
        {
            InitializeComponent();
            SystemEvents.SessionSwitch += OnSessionSwitch;
     
            this.WindowState = FormWindowState.Normal;
     
            this.Focus();
            this.BringToFront();
            this.TopMost = true;
        }
     
     
    void OnSessionSwitch(object sender, SessionSwitchEventArgs e)
         {
     
            switch (e.Reason)
            {
                case SessionSwitchReason.SessionLogon:
                    // User has logged on to the computer.
     
                    break;
     
                case SessionSwitchReason.SessionLogoff:
                    // User has logged off from the computer.
                    break;
     
                case SessionSwitchReason.SessionUnlock:
                    this.WindowState = FormWindowState.Normal;
                    this.Show();
     
                    break;
     
                case SessionSwitchReason.SessionLock:
                    // The computer has been locked.
                    break;
         }
     
     
     }
     
     private void button1_Click(object sender, EventArgs e)
     {
         this.Hide();
         this.WindowState = FormWindowState.Minimized;
     
     }
