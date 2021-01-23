    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Worker _worker;
        private async void button1_Click(object sender, EventArgs e)
        {
            Progress<int> progress = new Progress<int>(i => progressBar1.Value = i);
            _worker = new Worker();
            _worker.IsPausedChanged += (sender1, e1) =>
            {
                Invoke((Action)(() =>
                {
                    button3.Enabled = !_worker.IsPaused;
                    button4.Enabled = _worker.IsPaused;
                }));
            };
            button1.Enabled = false;
            button2.Enabled = button3.Enabled = true;
            try
            {
                await Task.Run(() => _worker.Run(progress));
                // let the progress bar catch up before we clear it
                await Task.Delay(1000);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Operation was cancelled");
            }
            progressBar1.Value = 0;
            button2.Enabled = button3.Enabled = button4.Enabled = false;
            button1.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _worker.Cancel();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            _worker.Pause();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            _worker.Resume();
        }
    }
