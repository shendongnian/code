    protected override void OnPropertyChanged(string propertyName)
    {
    	base.OnPropertyChanged(propertyName);
    	if (propertyName == StepIndicator.IsLeftButtonVisibleProperty.PropertyName)
    	{
    		this.imageLeft.IsVisible = newValue;
    	}
    }
