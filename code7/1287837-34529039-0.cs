     private static DispatcherTimer idleTimer;
     private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                idleTimer = new DispatcherTimer();
                idleTimer.Interval = TimeSpan.FromSeconds(5);
                idleTimer.Tick += this.OnTimerTick;
                idleTimer.Start();
            }
