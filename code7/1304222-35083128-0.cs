    public partial class MainWindow : Window
    {
        BackgroundWorker bw;
        long l_file;
        public MainWindow()
        {
            InitializeComponent();
        }
        string fileName = "";
        private void InitializeBackgroundWorker()
        {   
            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.ProgressChanged += Bw_ProgressChanged;            
            bw.WorkerReportsProgress = true;
        }
        
        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadFile(fileName);
        }
        private void btnOpenFLD_Click(object sender, RoutedEventArgs e)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            OpenFileDialog ofd = new OpenFileDialog();            
            if (ofd.ShowDialog() == true)
            {                
                FileInfo fileInfo = new FileInfo(ofd.FileName);
                l_file = fileInfo.Length;
                fileName = ofd.FileName;
                InitializeBackgroundWorker();
                bw.RunWorkerAsync();
            }            
        }        
        private void ReadFile(string fileName)
        {
            string line;
            long onePercent = l_file / 100;
            long lineLength = 0;
            long flagLength = 0;
            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.ASCII))
            {
                while (sr.EndOfStream == false)
                {
                    line = sr.ReadLine();
                    lineLength = line.Length;
                    flagLength += lineLength+2;
                    //Thread.Sleep(1);//uncomment it if you want to simulate a 
                    //very heavy weight file
                    if (flagLength >= onePercent)
                    {
                        CountProgressBar += 1;
                        bw.ReportProgress(CountProgressBar);
                        flagLength %= onePercent;
                    }
                }
            }
        }
        int countProgressBar = 0;
        private int CountProgressBar
        {
            get { return countProgressBar; }
            set
            {
                if (countProgressBar < 100)
                    countProgressBar = value;
                else
                    countProgressBar = 0;
            }
        }
    }
