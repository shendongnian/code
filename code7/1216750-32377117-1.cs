	public async void SomeButtonClick(object sender, EventArgs e)
	{
		var result = await SomeAsyncOperation().ConfigureAwait(false);
		textBox.Text = result;
	}
