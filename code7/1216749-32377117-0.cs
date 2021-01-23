	public async void SomeButtonClick(object sender, EventArgs e)
	{
		var result = SomeAsyncOperation().ConfigureAwait(false);
		textBox.Text = result;
	}
