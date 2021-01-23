    private void sldRotate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
    	if (_shape != null)
    	{
	    	var rt = new RotateTransform();
		    rt.Angle = sldRotate.Value;
	    	_shape.RenderTransform = rt;
	    	_shape.RenderTransformOrigin = new Point(0.5, 0.5);
    	}
    }
