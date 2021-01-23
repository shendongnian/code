        async private void Button_Click(object sender, RoutedEventArgs e)
    {
      Window1 win = new Window1();
      this.IsEnabled = false;
      win.Show();
      await Task.Run(() =>
        {
          Thread.Sleep(2000);
        });
      win.Close();
      this.IsEnabled = true;
    }
