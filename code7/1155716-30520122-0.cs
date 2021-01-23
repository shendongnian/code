    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Interval = 1000; // 1 second.
            this.timer.Tick += OnTimerFired;
            this.timer.Start();
        }
        private void OnTimerFired(object sender, EventArgs e)
        {
            this.textBox1.Text = "This was set safely.";
        }
    }
