	private string _currentlyOpenedFile;
	public void FileOpen_Click(...)
	{
		var openFileDialog = new ...OpenFileDialog();
		
		if (openFileDialog.ShowDialog())
		{
			// Save the filename when opening a file.
			_currentlyOpenedFile = openFileDialog.FileName;
		}
	}
	public void FileNew_Click(...)
	{
		// Clear the filename when closing a file or making a new file.
		_currentlyOpenedFile = null;
	}
	public void FileSave_Click(...)
	{
		if (_currentlyOpenedFile == null)
		{
			// New file, treat as SaveAs
			FileSaveAs_Click();
			return;
		}
	}
	public void FileSaveAs_Click(...)
	{
		var saveFileDialog = new ...SaveFileDialog();
		
		if (openFileDialog.ShowDialog())
		{
			// Write the file.
			File.WriteAllText(text, openFileDialog.FileName);
		
			// Save the filename after writing the file.
			_currentlyOpenedFile = openFileDialog.FileName;
		}
	}
