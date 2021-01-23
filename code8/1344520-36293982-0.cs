    public partial class MainWindow : Window {
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        List<int> listDummy = new List<int>();
        public MainWindow() {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
        }
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            var numberOfItems = 111;
            for (int i = 0; i < numberOfItems; i++) {
                listDummy.Add(i);
                Thread.Sleep(500);
                backgroundWorker.ReportProgress(Convert.ToInt32((double)i / numberOfItems * 100));
            }
        }
        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            backgroundWorker.RunWorkerAsync();
        }
    }
