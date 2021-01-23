    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(1);
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Start();
        }
    
        void timer_Tick(object sender, EventArgs e)
        {
            if (this.dropData != null) {
                ProcessDropData(this.dropData);
                this.dropData = null;
            }
        }
    
        private void Window_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                this.dropData = e.Data.GetData(DataFormats.FileDrop);
            }
        }
    
        private void ProcessDropData(object data)
        {
            string[] paths = (string[])data;
            // do work here
        }
    
        private DispatcherTimer timer;
        private object dropData;
    }
