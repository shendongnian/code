	List<DependencyObject> hitResultsList = new List<DependencyObject>();
	// Return the result of the hit test to the callback.
	public HitTestResultBehavior MyHitTestResult(HitTestResult result)
	{
		// Add the hit test result to the list that will be processed after the enumeration.
		hitResultsList.Add(result.VisualHit);
		// Set the behavior to return visuals at all z-order levels.
		return HitTestResultBehavior.Continue;
	}
	private void shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		// Retrieve the coordinate of the mouse position.
		Point pt = Mouse.GetPosition(grid);
		// Clear the contents of the list used for hit test results.
		hitResultsList.Clear();
		// Set up a callback to receive the hit test result enumeration.
		VisualTreeHelper.HitTest(grid, null,
			new HitTestResultCallback(MyHitTestResult),
			new PointHitTestParameters(pt));
		foreach (var ee in hitResultsList)
		{
			if(ee is Ellipse)
			{
				MessageBox.Show("rectangle clicked!");
			}
			if(ee is Rectangle)
			{
				MessageBox.Show("ellipse clicked!");
			}
		}
	}
