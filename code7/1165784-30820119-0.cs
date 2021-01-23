    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            Task task = new Task(new Action(() => ExecuteOnSeparateThread()));
            task.Start();
        }
    
        private void ExecuteOnSeparateThread()
        {
            Thread.Sleep(2000);
    
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, 
                new Action(() => Label.Foreground = Brushes.Red));
        }
    }
