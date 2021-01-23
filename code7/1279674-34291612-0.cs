            DispatcherTimer tgtTimer = new DispatcherTimer();
            DispatcherTimer txbTimer2 = new DispatcherTimer();
            DispatcherTimer rt = new DispatcherTimer();
    public void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            tgtTimer.Tick += new EventHandler(tgtTimer_tick);
            tgtTimer.Interval = new TimeSpan(0, 0, 3);
            tgtTimer.Start();
    
    
            txbTimer2.Tick += new EventHandler(txbTimer2_tick);
            txbTimer2.Interval = new TimeSpan(0, 0, 0, 4, 000);
            txbTimer2.Start();
    
            rt.Tick += new EventHandler(rt_tick);
            rt.Interval = new TimeSpan(0, 0, 1);
            rt.Start();
        }
