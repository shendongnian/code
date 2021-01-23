	public bool AllPositionsEqual
	{
		get
		{
			return Top == Bottom 
				&& Left == Right
				&& Left == Top;
		}
	}
