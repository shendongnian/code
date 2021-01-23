    private void grid_Loaded(object sender, RoutedEventArgs e)
    {
         var g = (Grid) sender;
         var animation = g.Resources["rotator"] as DoubleAnimation;        
         gridRotation.BeginAnimation(RotateTransform.AngleProperty, animation);
    }
