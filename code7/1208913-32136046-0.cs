     private void MyButton_Click(object sender, RoutedEventArgs e)
        {
             Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() => txtUserEntry.Focus()));
        }
     
