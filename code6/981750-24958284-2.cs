    public partial class Form1 : Form
    {
        MyAsyncClass worker;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            label1.Text = string.Format("Worker Started at {0}", DateTime.Now);
            if (worker == null)
            {
                worker = new MyAsyncClass();
                worker.NotifyCompleteEvent += worker_NotifyCompleteEvent;
            }
            worker.Start();
        }
        void worker_NotifyCompleteEvent(string message)
        {
            MessageBox.Show(string.Format("Worker completed with message: {0}", message));
        }
    }
