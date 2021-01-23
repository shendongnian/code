      public static void ShowSplash(bool isIndeterminate = false)
        {
            _thread = new Thread(new ThreadStart(OpenSplash))
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
            _isIndeterminate = false;
 
           _splash.Show();
            System.Windows.Threading.Dispatcher.Run();
           
            //_splash.Dispatcher.Invoke(new Action(Dispatcher.Run));
            System.Windows.Threading.Dispatcher.Run(); //HERE!
            _splash.Dispatcher.Invoke(() => { _splash.ProgressBar.IsIndeterminate = _isIndeterminate; });
        }
