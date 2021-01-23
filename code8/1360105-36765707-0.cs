     DispatcherTimer timer;
            private void button_Click(object sender, RoutedEventArgs e)
            {
                if (timer == null)
                {
                    timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(5) };
                    timer.Tick += Timer_Tick;
                }
            }
     private void Timer_Tick(object sender, object e)
            {
                timer.Stop();
                Frame.Navigate(typeof(MainPage));//Give your page here
            }
