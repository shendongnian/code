    public static ICommand ToggleSelection { get { return new RelayCommand<GridViewControl>(GridViewToggleSelectionCommand); } }
	private static void GridViewToggleSelectionCommand(GridViewControl theControl)
	{
		// do something with the control here
	}
