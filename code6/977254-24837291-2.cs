    protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
			Metrics.Instance.Width=width;
            Metrics.Instance.Height=height;
        }
