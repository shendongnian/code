    private void AddRectangle() {
    	Rectangle rotatedRectangle = new Rectangle();
        rotatedRectangle.Width = 200;
        rotatedRectangle.Height = 50;
        rotatedRectangle.Fill = Brushes.Blue;
        rotatedRectangle.Opacity = 0.5;
        RotateTransform rotateTransform1 = new RotateTransform(45, -50, 50);
        rotatedRectangle.RenderTransform = rotateTransform1;
    
        MyGridContainer.Children.Add(rotatedRectangle);
    }
