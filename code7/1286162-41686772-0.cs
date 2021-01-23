    private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (e.NewValue != newValue)
        {
           newValue = e.NewValue;
           // DO SOMETHING
        }
    }
