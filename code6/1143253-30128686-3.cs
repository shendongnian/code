    private void text_PasswordChanged(object sender, TextChangedEventArgs e)
    {
        if (text.Password.Length >= 8)
        {
          if (text.Password.ValidatePassword())
          {
             text.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
          }
          else
             text.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }
        else
          text.Background = SystemColors.WindowBrush;
     }
