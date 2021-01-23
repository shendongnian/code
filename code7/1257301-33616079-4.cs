    public partial class Form1 : Form
    {
        private Timer farmProgress;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            farmProgress = new Timer();
            farmProgress.Tick += farmProgress_Tick;
            farmProgress.Interval = 1000; // in miliseconds
            farmProgress.Start();
        }
        void farmProgress_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
        }
    }
