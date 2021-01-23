        DispatcherTimer timer = new DispatcherTimer();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Tick += Roll;
            timer.Interval = new TimeSpan(1);
            
            Random r = new Random();
            timer.Start();
        }
        Random r = new Random();
        public void Roll(object sender, EventArgs e)
        {
            increment++;
            if (increment >= 250)
            {
                timer.Stop();
                increment = 0;
            }
            DiceLabel.Content = r.Next(1, 7).ToString();
            timer.Interval = new TimeSpan(increment*3000);
        }
