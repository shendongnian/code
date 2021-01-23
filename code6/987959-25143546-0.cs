    public partial class CountDown : ServiceBase
    {
        public CountDown()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            _fs = System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt");
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerElapsed);
            _timer.AutoReset = true;
            _timer.Start();
        }
        protected override void OnStop()
        {
            _fs.Close();
            _timer.Close();
        }
        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var message = String.Format("{0} - Count #{1}\n", DateTime.Now, _counter++);
            var bytes = System.Text.Encoding.ASCII.GetBytes(message);
            _fs.Write(bytes, 0, bytes.Length);
        }
        private System.Timers.Timer _timer;
        private System.IO.FileStream _fs;
        private int _counter;
    }
