            public void StartTimer()
            {
                var timer = new DispatcherTimer();
                timer.Tick += Something;
                timer.Interval = new TimeSpan(0, 0, 0, 3);
                timer.Start();
    
            }
    
            private async void Something(Object sender, EventArgs e)
            {      
             //code goes here....
            }
