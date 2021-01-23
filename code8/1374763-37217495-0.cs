	public static readonly DependencyProperty SuggestionsSourceProperty =
	DependencyProperty.Register("SuggestionsSource", typeof(IList), typeof(MySchedulerDialog), new UIPropertyMetadata(null));
	public IList SuggestionsSource
	{
		get { return (IList)GetValue(SuggestionsSourceProperty); }
		set { SetValue(SuggestionsSourceProperty, value); }
	}
