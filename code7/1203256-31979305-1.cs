    private void ButtonOne_MouseLeave(object sender, MouseEventArgs e)
    {
        Point leavePoint = e.GetPosition(ButtonOne);
        if (leavePoint.X < ButtonOne.ActualWidth)
        {
            Pop1.IsOpen = false;
        }
    }
    
    private void ButtonTwo_MouseLeave(object sender, MouseEventArgs e)
    {
        Point leavePoint = e.GetPosition(ButtonTwo);
        if (leavePoint.X < ButtonTwo.ActualWidth)
        {
            Pop2.IsOpen = false;
        }
    }
    
