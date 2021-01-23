    double angle = ....;
    var animation = new DoubleAnimation
    {
        To = angle,
        Duration = TimeSpan.FromSeconds(1)
    };
    var transform = ((TransformGroup)shape_01.RenderTransform)
        .Children.OfType<RotateTransform>().First();
    transform.BeginAnimation(RotateTransform.AngleProperty, animation);
