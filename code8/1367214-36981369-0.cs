	private int _listIndex = -1;
	private IList<string> _listToFill = null;
	private void StartFilling(IList<string> myList)
	{
		if (!myList.Any())
			return;
		_listToFill = myList;
		_listIndex = 0;
		mySampleInputBox.Text = "";
		mySampleInputBox.Visible = true;
		mySampleInputBox.Focus();
	}
	private void mySampleInputBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Enter)
			return;
		var tb = (TextBox)sender;
		_listToFill[_listIndex++] = tb.Text;
		tb.Text = "";
		if (_listIndex >= _listToFill.Count())
		{
			tb.Visible = false;
			_listIndex = -1;
			_listToFill = null;
		}
	}
