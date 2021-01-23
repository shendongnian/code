    public partial class YourForm : Form
    {
        public YourForm()
        {
            InitializeComponets();
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += timer_Tick;
            _timer.Interval = 1000;
         }
    
        private System.Windows.Forms.Timer _timer;
        private int time = 30;
        private void Check_Click(object sender, RoutedEventArgs e)
        {
        time = 30;
        _timer.Start();
        uxLabel1.Content = time.ToString();
        //additional code
        }
        private void timer_Tick(object sender, EventArgs e)
        {
        time--;
        if (time == 0)
        {
        _timer.Stop();
        strike();
        }
        uxLabel1.Content = time.ToString();
        }
    }
