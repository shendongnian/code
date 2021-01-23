    public partial class Form1 : Form
    {
        BackgroundWorker backgroundWorker;
        public Form1()
        {
            InitializeComponent();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += OnDoWork;
        }
        void OnDoWork(object sender, DoWorkEventArgs e)
        {
            // Long running code here.
        }
    }
