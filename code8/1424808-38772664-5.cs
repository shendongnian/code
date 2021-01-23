    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Popup1.IsOpen = true;
    }
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        Popup1.IsOpen = false;
    }
    private void Window1_LocationChanged(object sender, EventArgs e)
    {
        double offset = Popup1.HorizontalOffset;
        Popup1.HorizontalOffset = offset + 1;
        Popup1.HorizontalOffset = offset;
    }   
