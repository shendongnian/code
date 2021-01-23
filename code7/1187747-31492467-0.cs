    protected void LostFocusEvent(object sender, RoutedEventArgs e)
    {
        if(textBox.Text.Length>0)
        {
          // if there is any character in TextBox
        return;
        }
    
       // your validation Code goes here
    }
