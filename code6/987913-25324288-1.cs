    protected override void OnStartup(object sender, StartupEventArgs e)
        {
            var splash = this.container.GetExportedValue<SplashScreenViewModel>();
            var windowManager = IoC.Get<IWindowManager>();
            windowManager.ShowDialog(splash);
           // do your background work here using
            var bw = new BackgroundWorker();
            bw.DoWork += (s, e) =>
                {
                    // Do your background process here
                    
                };
            bw.RunWorkerCompleted += (s, e) =>
                {
                    // close the splash window
                    splash.TryClose();
                    this.DisplayRootViewFor<ShellViewModel>();
                }; 
            bw.RunWorkerAsync();           
        }
        // your ShellViewModel
        [ImportingConstructor]
        public ShellViewModel(MainViewModel mainViewModel)
        {
            this.DisplayName = "Window Title";
            // no need to new
            this.ActivateItem(mainViewModel);
        }
  
