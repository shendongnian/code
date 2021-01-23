    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] GenerateList() => new string[500];
        void DoWork()
        {
            Thread.Sleep(50);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var list = GenerateList();
            progressBar1.Maximum = list.Length;
            Task.Run(() => Parallel.ForEach(list, item =>
            {
                DoWork();
                // Update the progress bar on the Synchronization Context that owns this Form.
                this.Invoke(new Action(() => this.progressBar1.Value++));
            }));
        }
    }
