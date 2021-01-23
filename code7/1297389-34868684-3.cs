    public PointerPoint pointer1;
    
    private void OnPointerExited(object sender, PointerRoutedEventArgs e)
    {
        var pointer2 = e.GetCurrentPoint(myPivot);
        var position1x = pointer1.Position.X;
        var position2x = pointer2.Position.X;
        if (position2x > position1x)
        {
            if (myPivot.SelectedIndex == 0)
                myPivot.SelectedIndex = 1;
            else
                myPivot.SelectedIndex = 0;
        }
        else
            return;
    }
    
    private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
    {
        pointer1 = e.GetCurrentPoint(myPivot);
    }
