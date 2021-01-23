    private void ReSetScreen()
    {
        if (!Dispatcher.CheckAccess())
        {
            Application.Current.Dispatcher.BeginInvoke(ReSetScreen);
            return;
        }
        ucCustomerNew.Visibility = Visibility.Hidden;
        ucCustomerResults.Visibility = Visibility.Hidden;           
    }
