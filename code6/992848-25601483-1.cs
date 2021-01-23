	double xadjust = this.ActualWidth + e.HorizontalChange;
	double yadjust = this.ActualHeight + e.VerticalChange;
	if ((xadjust >= this.MinWidth) && (yadjust >= this.MinHeight))
	{
		this.Width = xadjust; 
		this.Height = yadjust;
	}
