	private void TextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Enter)
		{
			TextBox txtBox = sender as TextBox;
			txtBox.Text += Environment.NewLine + "-";
			txtBox.CaretIndex = txtBox.Text.Length;
		}
	}
