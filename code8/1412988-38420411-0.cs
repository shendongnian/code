    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer;
        int milliseconds;
        const int TIME_TO_MINIMIZE = 1000;
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += new MouseEventHandler(InputAction);
            this.MouseClick += new MouseEventHandler(InputAction);
            this.KeyPress += new KeyPressEventHandler(InputAction);
            milliseconds = 0;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            milliseconds += 100;
            if (milliseconds >= TIME_TO_MINIMIZE)
            {
                this.WindowState = FormWindowState.Minimized;
                milliseconds = 0;
            }
        }
        private void InputAction(object sender, EventArgs e)
        {
            milliseconds = 0;
        }
    }
