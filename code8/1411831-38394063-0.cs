    protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
    {
    	if (InputManager.Current.MostRecentInputDevice is StylusDevice)
    	{
    		return base.HitTestCore(hitTestParameters);
    	}
    	return null;
    }
