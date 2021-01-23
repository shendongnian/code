    public class MainWindow : Window
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();
    
        public MainWindow()
        {
            this.Loaded += MyWindow_Loaded;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
    
        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Start the background worker. May be better started off on a button or something else app specific
            worker.RunWorkerAsync();
        }
    
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
           // run all .exes here...
           // Note: you cannot access the GUI elements directly from the background thread
           RunCalculator();
           RunOtherExes();
        }
    
        private void worker_RunWorkerCompleted(object sender, 
                                               RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete its work
        }
      
        private void RunCalculator()
        {
            var p = new Process();
            p.StartInfo.FileName = query;
            p.StartInfo.WorkingDirectory = path;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = String.Join(" ", calculator.Arguments);
            p.Start();
            p.WaitForExit();
        }
    
        private void RunOtherExes()
        {
            // ...
        }
    
    }
