    public partial class Form1 : Form
    {
        Progress<int> counterProgress;
        public Form1()
        {
            InitializeComponent();
            counterProgress = new Progress<int>();
            counterProgress.ProgressChanged += CounterProgressUpdated;
        }
        private void CounterProgressUpdated(object sender, int e)
        {
            textBox1.Text = e.ToString();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await taskAsync(counterProgress);
        }
        private Task taskAsync(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() => counter(progress));
        }
        private async Task counter(IProgress<int> progress)
        {
            for (int i = 0; i < 10000; i++)
            {
                await Task.Delay(1000);
                progress.Report(i);                
            }
        }
    }
