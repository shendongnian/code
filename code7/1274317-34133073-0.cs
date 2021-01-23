	public static readonly DependencyProperty IsInEditModeProperty =
	 DependencyProperty.Register("IsInEditMode", typeof(bool), typeof(EditableTextBox),
     new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		
	public bool IsInEditMode
	{
		get { return (bool)GetValue(IsInEditModeProperty); }
		set { SetValue(IsInEditModeProperty, value); }
	}
