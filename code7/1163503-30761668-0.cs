    private void myCustomControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            //do something
            e.Handled = true;
        }
    }
