    public double pointx1;
    
    private void OnCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
    {
        var pointx2 = Window.Current.CoreWindow.PointerPosition.X;
        if (pointx2 > pointx1)
        {
            if (myPivot.SelectedIndex == 0)
                myPivot.SelectedIndex = 1;
            else
                myPivot.SelectedIndex = 0;
        }
        else
            return;
    }
    
    private void OnStarting(object sender, ManipulationStartingRoutedEventArgs e)
    {
        pointx1 = Window.Current.CoreWindow.PointerPosition.X;
    }
