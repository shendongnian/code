    public partial class App : Application
    {
        private static Splash _splash;
        private static bool _isIndeterminate = false;
        private static Thread _thread;
        protected override void OnStartup(StartupEventArgs e)
        {
            ShowSplash(true);
            Thread.Sleep(5000);
        }
        public static void ShowSplash(bool isIndeterminate = false)
        {
            _isIndeterminate = isIndeterminate;
            _thread = new Thread(OpenSplash)
            {
                IsBackground = true,
                Name = "Loading"
            };
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }
        private static void OpenSplash()
        {
            //Run on another thread.
            _splash = new Splash();
            _splash.Show();
            _splash.ProgressBar.IsIndeterminate = _isIndeterminate;
            //_splash.Dispatcher.Invoke(new Action(Dispatcher.Run));
            System.Windows.Threading.Dispatcher.Run(); //HERE!
        }
        public static void CloseSplash()
        {
            if (_splash == null || _thread == null)
                return;
            _splash.Dispatcher.Invoke(new Action(() => { _splash.Close(); }));
            _splash.Dispatcher.InvokeShutdown();
            _splash = null;
        }
        public static void Update(int value, string description)
        {
            Update((double)value, description);
        }
        public static void Update(double value, string description)
        {
            if (_splash == null)
                return;
            _splash.Dispatcher.Invoke((Action)delegate
            {
                //It takes 120 ms to progress 10%.
                var da = new DoubleAnimation(value, new Duration(TimeSpan.FromMilliseconds(Math.Abs(_splash.ProgressBar.Value - value) * 12)))
                {
                    EasingFunction = new PowerEase { Power = 3 }
                };
                _splash.ProgressBar.BeginAnimation(RangeBase.ValueProperty, da);
                _splash.textBlock.Text = description;
            });
        }
    }
