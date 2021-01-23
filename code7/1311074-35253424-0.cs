            protected override void OnStartup(StartupEventArgs e)
            {
                MainWindow window = new MainWindow();
                window.Visibility = Visibility.Hidden;
                new Task(() =>
                {
                    Splash splashScr = null;
                    Dispatcher.Invoke(() =>
                    {
                        splashScr = new MainWindow();
                        splashScr.Show();
                    });
                    Stopwatch splashTimer = new Stopwatch();
                    splashTimer.Start();
    
                    splashScr.SplashInfo = "Ładowanie ....";
    
                    splashTimer.Stop();
    
                    int splashRemainingTime = splashMinTime - (int)splashTimer.ElapsedMilliseconds;
                    if (splashRemainingTime > 0)
                        Thread.Sleep(splashRemainingTime);
    
                    Dispatcher.Invoke(() =>
                    {
                        splashScr.Close();
                        window.Visibility = Visibility.Visible;
                    });
                }).Start();
    
                base.OnStartup(e);
            }
