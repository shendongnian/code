    DispatcherTimer tgtTimer = new DispatcherTimer();
    DispatcherTimer tgtTimer2 = new DispatcherTimer();
    
    public void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {            
            DispatcherTimer tgtTimer = new DispatcherTimer(); //here
            tgtTimer.Tick += new EventHandler(tgtTimer_tick);
            tgtTimer.Interval = new TimeSpan(0, 0, 3);
            tgtTimer.Start();
    
    
            DispatcherTimer txbTimer2 = new DispatcherTimer(); //and here
            txbTimer2.Tick += new EventHandler(txbTimer2_tick);
            txbTimer2.Interval = new TimeSpan(0, 0, 0, 4, 000);
            txbTimer2.Start();
    
            //or inline the method to stay within scope
            DispatcherTimer rt = new DispatcherTimer();
            rt.Tick += (ob, ev) =>
            {
                  //still in scope
                  txbTimer2.Start();
            };
            rt.Interval = new TimeSpan(0, 0, 1);
            rt.Start();
    }
