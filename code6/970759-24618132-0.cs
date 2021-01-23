    var doubleAnimation = new DoubleAnimation(360, 0, new Duration(TimeSpan.FromSeconds(1)));
    var rotateTransform = new RotateTransform();
    image.RenderTransform = rotateTransform;
    image.RenderTransformOrigin = new Point(0.5, 0.5);
    doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
    rotateTransform.BeginAnimation(RotateTransform.AngleProperty, doubleAnimation);
