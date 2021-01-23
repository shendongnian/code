    private void RefreshTick_Change(object sender, SelectionChangedEventArgs e)
            {
                if (timer == null) return;
    
                int period = Int32.Parse(((ComboBoxItem)RefreshTick.SelectedItem).Content.ToString());
                timer.Interval = TimeSpan.FromSeconds(period);
                timer.Stop();
                timer.Start();
            }
