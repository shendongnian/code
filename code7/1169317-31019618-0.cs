    void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs a)
    {
       try
       {
           this.Focus();
       }
       finally
       {
           a.Handled = true;
       }
    }
