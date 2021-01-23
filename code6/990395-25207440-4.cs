    public void ExecuteAnimatedSnapTo(Action<Point> animatedSnapToAction, Point pointerPosition)
	{
		if (animatedSnapToAction != null && pointerPosition != null)
		{
			// Create a new point based on the one passed in and data in ViewModel
			Point newPoint =
				new Point(pointerPosition.X + viewModelData.X, pointerPosition.Y + viewModelData.Y);
			// Invoke the delegate using the new point
			animatedSnapToAction(newPoint);
		}
	}
