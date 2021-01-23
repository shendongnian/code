	public MyPageViewModel()
	{
		_selectedText = "Welcome";   //Default text
		SomeTask().ContinueWith(previousTask => SelectedText = previousTask.Result);
	}
