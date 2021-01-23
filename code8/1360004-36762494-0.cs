    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConsumerThread.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            foreach (var i in Enumerable.Range(0, 10))
                _processCollection.Add(() => BigTask(i));
        }
        static BlockingCollection<Func<Task>> _processCollection = new BlockingCollection<Func<Task>>();
        Thread ConsumerThread = new Thread(LaunchConsumer);
        private static async void LaunchConsumer()
        {
            while (true)
            {
                var processTask = _processCollection.Take();
                await Task.Run(processTask);
            }
        }
        async Task BigTask(int i)
        {
            await Task.Delay(5000);
            textBox2.Invoke(new Action(() => textBox2.AppendText($"Text{i}\n")));
        }
    }
