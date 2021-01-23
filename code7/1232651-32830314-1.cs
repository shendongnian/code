    public partial class Form1 : Form
    {
        private Int64 value = -1;
        private bool Paused = true;
        private int IntervalInMilliseconds = 100;
        private System.Threading.ManualResetEvent mre = new System.Threading.ManualResetEvent(false);
        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
        }
        private async void Form1_Shown(object sender, EventArgs e)
        {
            await Task.Run(delegate ()
            {
                while (true)
                {
                    value++;
                    label1.Invoke((MethodInvoker)delegate ()
                    {
                        label1.Text = value.ToString();
                    });
                    System.Threading.Thread.Sleep(IntervalInMilliseconds);
                    mre.WaitOne();
                }
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            if (Paused)
            {
                mre.Set();
            }
            else
            {
                mre.Reset();
            }
            Paused = !Paused;
        }
	}
