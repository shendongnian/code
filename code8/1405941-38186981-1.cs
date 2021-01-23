    private void loadButton_Click(object sender, RoutedEventArgs e)
    {
      Task.Run(() =>
      {
        Dispatcher.Invoke(() =>
        {
          try
          {
            textBox.Text = File.ReadAllText(@"d:\test.txt");
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.ToString());
          }
        });
      });
    }
    
    private void saveButton_Click(object sender, RoutedEventArgs e)
    {
      Task.Run(() =>
      {
        Dispatcher.Invoke(() =>
        {
          try
          {
            File.WriteAllText(@"d:\test.txt", textBox.Text);
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.ToString());
          }
        });
      });
    }
