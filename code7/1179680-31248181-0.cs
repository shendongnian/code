        System.Timers.Timer t;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            t = new System.Timers.Timer();
            t.Elapsed += t_Elapsed;
            t.Interval = 1000;
            t.Start();
        }
        int tickCount = 0;
        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            tickCount++;
            switch (tickCount)
            {
                case 1: textBox.Text = "one"; break;
                case 2: textBox.Text = "two"; break;
                case 3: textBox.Text = "three"; break;
                case 4: textBox.Text = "four"; break;
                case 5: t.Stop(); break;
            }
        }
