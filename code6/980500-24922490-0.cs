    using System.Windows.Threading;
    namespace BasicTimer
    {
        public partial class MainWindow : Window
        {
            DispatcherTimer t;
            DateTime start;
            public MainWindow()
            {
                InitializeComponent();
                t = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 50), DispatcherPriority.Background,
                    t_Tick, Dispatcher.CurrentDispatcher); t.IsEnabled = true;
                start = DateTime.Now;
            }
            private void t_Tick(object sender, EventArgs e)
            {
                TimerDisplay.Text = Convert.ToString(DateTime.Now - start);
            }
