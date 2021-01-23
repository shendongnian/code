	SolidColorBrush IsOnABackground
	{
		get
		{
			if(IsOnA)
				return (SolidColorBrush)Application.Current.Resources["HighlightBackgroundColorBrush"];
			else
				return (SolidColorBrush)Application.Current.Resources["NormalBackgroundColorBrush"];
		}
	}
	bool isOnA = false;
	bool IsOnA
	{
		set
		{
			if (isOnA != value)
			{
				isOnA = value;
				OnPropertyChanged("IsOnA");
				OnPropertyChanged("IsOnABackground");
			}
		}
		get { return isOnA; }
	}
