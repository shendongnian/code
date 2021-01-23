	// get/set methods omitted
	public static readonly DependencyProperty CounterProperty = DependencyProperty.RegisterAttached(
		"CellsCounter", 
		typeof(Counter), 
		typeof(GridBehavior), 
		new FrameworkPropertyMetadata(GridBehavior.OnCellsCounterPropertyChanged));
	private static void OnCellsCounterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var oldCounter = e.OldValue as Counter;
		if (oldCounter != null)
		{
			oldCounter.Remove(d);
		}
		var newCounter = e.NewValue as Counter;
		if (newCounter != null)
		{
			var isSelected = GridBehavior.GetIsSelected(d);
			if (isSelected)
			{
				newCounter.Add(d);
			}
		}
	}
