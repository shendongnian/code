    <Button Content="Button" HorizontalAlignment="Left" Margin="165,58,0,0" VerticalAlignment="Top" Width="75" Click="Button_Click"/>
    
     private BackgroundWorker _backgroundWorker;
            public MainWindow()
            {
                InitializeComponent();
                _backgroundWorker = new BackgroundWorker();
                _backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                _backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
                _backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
                _backgroundWorker.WorkerReportsProgress = true;
                DataContext = this;
              
               
            }
    
            private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                var eee = e.Result;
            }
    
            private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                var progrss = e.ProgressPercentage;
            }
    
            private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                int p=10;
                for (int index = 0; index < p; index++)
    			{
                    object param = "something";
                    Thread.Sleep(100);
                    _backgroundWorker.ReportProgress(p, param);
                    Thread.Sleep(1000);
                    if (index == 10)
                    {
                        break;
                    } 
    			} 
                
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                _backgroundWorker.RunWorkerAsync(); 
            }
