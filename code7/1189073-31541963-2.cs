    public partial class Form1 : Form
    {
        IntPtr hWndToStayOver = User32.FindWindow("Vega Prime", "Vega Prime");
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.Form1_Load);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start(); // Routine starts now that I'm sure my Form exists
        }
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop(); // Stop routine (my Form doesn't exist anymore)
        }
        private bool AmIAboveOtherWindow()
        {
            IntPtr tmpHwnd = User32.GetNextWindow(hWndToStayOver, User32.GetNextWindowCmd.GW_HWNDPREV);
            while (tmpHwnd != (IntPtr)0)
            {
                if (tmpHwnd == this.Handle)
                    return true;
                tmpHwnd = User32.GetNextWindow(tmpHwnd, User32.GetNextWindowCmd.GW_HWNDPREV);
            }
            return false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (!AmIAboveOtherWindow()) // Check if I am behind the target window
            {
                User32.SetWindowPos(this.Handle, hWndToStayOver, 0, 0, 0, 0, // Move my Form behind the target
                    User32.SetWindowPosFlags.SWP_NOMOVE |
                    User32.SetWindowPosFlags.SWP_NOSIZE |
                    User32.SetWindowPosFlags.SWP_SHOWWINDOW |
                    User32.SetWindowPosFlags.SWP_NOACTIVATE |
                    User32.SetWindowPosFlags.SWP_ASYNCWINDOWPOS);
                User32.SetWindowPos(hWndToStayOver, this.Handle, 0, 0, 0, 0, // Move target behind my Form
                    User32.SetWindowPosFlags.SWP_NOMOVE |
                    User32.SetWindowPosFlags.SWP_NOSIZE |
                    User32.SetWindowPosFlags.SWP_SHOWWINDOW |
                    User32.SetWindowPosFlags.SWP_NOACTIVATE |
                    User32.SetWindowPosFlags.SWP_ASYNCWINDOWPOS);
            }
            timer1.Start();
        }
    }
