	public ICommand ClosingCommand { get { return new RelayCommand<CancelEventArgs>(OnClosing); } }
	private void OnClosing(CancelEventArgs args)
	{
		if (!PromptUserForClose())
			args.Cancel = true;
	}
