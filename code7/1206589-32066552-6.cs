    public partial class MainWindow : Window
    {
        BackgroundWorker bw;
        public MainWindow()
        {
            InitializeComponent();
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWok;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }              
    }
    
    void bw_RunWorkerComleted(object sender, RunWorkerCompletedEventAgs e)
    {
        MessageBox.Show("The result is " + e.Result.ToString());
    }
    
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        foreach (var ticker in tickers)
        {
            var url = string.Format(urlPrototype, ticker, startMonth, startDay, startYear, finishMonth, finishDay, finishYear, "d");
            var csvfile = directory + "\\" + ticker.ToUpper() + ".csv";
            webClient.DownloadFile(url, csvfile);    
            numStocks++;
         }
        e.Result = "End Of Download ";
    }
    
    private void button_Click(object sender, RoutedEventArgs e)
    {
        bw.RunWorkerAsync();
        tbOutput.Text += "Starting Download of : " + ticker + "\n";
    }
