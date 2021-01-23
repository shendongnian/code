    public partial class frmTimer : Form
    {
        System.Windows.Forms.Timer timer;
        public frmTimer()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 10 * 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            // attach your events on which you want to reset your events
            this.MouseMove += FrmTimer_MouseMove;
            this.MouseDown += FrmTimer_MouseDown;
            this.KeyDown += FrmTimer_KeyDown;
        }
        private void FrmTimer_KeyDown(object sender, KeyEventArgs e)
        {
            timer.Stop();
            timer.Start();
        }
        private void FrmTimer_MouseDown(object sender, MouseEventArgs e)
        {
            timer.Stop();
            timer.Start();
        }
        private void FrmTimer_MouseMove(object sender, MouseEventArgs e)
        {
            timer.Stop();
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                this.WindowState = FormWindowState.Minimized;
        }
    }
