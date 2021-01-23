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
        System.Diagnostics.Debug.WriteLine("Window shifted");
        Point newpt = Window1.PointToScreen(new Point(0, 0));           
        Popup1.HorizontalOffset = newpt.X - oldpt.X;
        Popup1.VerticalOffset = newpt.Y - oldpt.Y;
        oldpt = newpt;
    }
    private void Window1_Activated(object sender, EventArgs e)
    {
        oldpt = Window1.PointToScreen(new Point(0, 0));
    }
