    private void button1_Click(object sender, RoutedEventArgs args)
    {
        int i = 0;
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(2);
        timer.Tick += (s, e) =>
        {
            if (i == 10)
            {
                timer.Stop();
            }
            else
            {
                textBox1.Text += "this is the " + i + "th line\n";
                ++i;
            }
        };
        timer.Start();
    }
