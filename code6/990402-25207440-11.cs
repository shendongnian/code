    private void dispatcherTimer_Tick(object sender, EventArgs e)
	{
		// Calculate geometry data
		
		if(AnimatedToSnapAction != null)
		{
			AnimatedSnapToAction(pointCalculatedUsingGeometryData);
		}
	}
