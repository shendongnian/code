    private void text_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (text.Text.Length >= 8)
        {
          if (text.Text.ValidatePassword())
          {
             text.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
          }
          else
             text.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }
        else
          text.Background = SystemColors.WindowBrush;
     }
