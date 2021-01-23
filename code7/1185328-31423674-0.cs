    public partial class MainWindow : Window
        {
            private System.Timers.Timer _timer;
            private int count = 0;
    
            public MainWindow()
            {
                InitializeComponent();
    
                _timer = new Timer(1000);
                _timer.Elapsed += _timer_Elapsed;
                _timer.Enabled = true;
                _timer.Start();
            }
    
            void _timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                this.Dispatcher.Invoke(UpdateProgressBar);
            }
    
            private void UpdateProgressBar()
            {
                progressBar1.Value = count;
                count++;
            }
        }
