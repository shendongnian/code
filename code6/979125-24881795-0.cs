    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            workerList = new List<BackgroundWorker>();
            for (int i = 0; i < 10; i++)
            {
                var el = new BackgroundWorker();
                el.DoWork += (s, e) =>
                {
                    Thread.Sleep(5000);
                };
                workerList.Add(el);
                checkedListBox1.Items.Add("el " + i);
            }
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var worker = workerList[e.Index];
            if (worker.IsBusy)
            {
                e.NewValue = e.CurrentValue;
                return;
            }
            if (e.NewValue == CheckState.Checked)
                worker.RunWorkerAsync();
        }
        public List<BackgroundWorker> workerList { get; set; }
    }
