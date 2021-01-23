    private bool editMode;
	public bool EditMode
	{
		get { return editMode; }
		set
		{
			editMode = value;
			OnPropertyChanged();
		}
	}
