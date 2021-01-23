    public static class MyDialog
	{
		public static int ShowDialog(string text, string caption)
		{
			Form prompt = new Form();
			prompt.Width = 500;
			prompt.Height = 100;
			prompt.Text = caption;
			Label textLabel = new Label() { Left = 50, Top=20, Text=text };
			NumericUpDown inputBox = new NumericUpDown () { Left = 50, Top=50, Width=400 };
			Button confirmation = new Button() { Text = "Ok", Left=350, Width=100, Top=70 };
			confirmation.Click += (sender, e) => { //YOUR FUNCTIONALITY };
			prompt.Controls.Add(confirmation);
			prompt.Controls.Add(textLabel);
			prompt.Controls.Add(inputBox);
			prompt.ShowDialog();
			
			return (int)inputBox.Value;
		}
	}
