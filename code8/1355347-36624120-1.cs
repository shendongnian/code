    public partial class Form1 : Form
    {
        private int i = 1;
        public Form1()
        {
            InitializeComponent();
        }
        private void FrqSent()
        {           
            while (i <= 500000000)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    break;
                }
                else
                {
                    i = i + 1;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            FrqSent();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(i.ToString());
        }
    }
