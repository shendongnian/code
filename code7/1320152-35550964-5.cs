	List<DependencyObject> hitResultsList = new List<DependencyObject>();
	// Return the result of the hit test to the callback.
	public HitTestResultBehavior MyHitTestResult(HitTestResult result)
	{
		hitResultsList.Add(result.VisualHit);
		return HitTestResultBehavior.Continue;
	}
	private void shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		Point pt = Mouse.GetPosition(grid);
		hitResultsList.Clear();
		VisualTreeHelper.HitTest(grid, null, new HitTestResultCallback(MyHitTestResult), new PointHitTestParameters(pt));
		foreach (var ee in hitResultsList)
		{
			if(ee is Ellipse)
			{
				MessageBox.Show("rectangle clicked!");
				var ellipse = ee as Ellipse;
				// Do something with ellipse
			}
			if(ee is Rectangle)
			{
				MessageBox.Show("ellipse clicked!");
				var rec = ee as Rectangle;
				// Do something with rectangle
			}
		}
	}
