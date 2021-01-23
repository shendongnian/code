    using System;
    using System.Windows;
    namespace StkOverflow
    {
    public partial class MainWindow
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public DateTime Time
        {
            get { return (DateTime)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(DateTime), typeof(MainWindow), new PropertyMetadata(DateTime.Now));
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }
        private void Timer_Click(object sender, EventArgs e)
        {
            Time = DateTime.Now;
        }
    }
    }
