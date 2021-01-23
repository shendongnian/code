    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            var timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (o, e) =>
            {
                if (bar.Value < bar.Maximum)
                    bar.Value++;
                else
                    timer.Stop();
            };
            timer.Start();
        }
    } 
