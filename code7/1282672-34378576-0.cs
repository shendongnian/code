	private void TranslateButton_Click(object sender, EventArgs e)
	{
		TranslateOutput.Text = "";
		if (specials.Any(s => TranslateBox.Text.Contains(s)))
		{
			MessageBox.Show("No Special Characters!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		else
		{
			String[] parts = TranslateBox.Text.Split();
			foreach (var part in parts)
			{
				var index = 1;
				if (vowels.Any(v => part.Substring(0, 1).ToLower() == v))
				{
					index = 0;
				}
				else if (new [] { "sh", "ch", "th", "tr", }.Contains(part.Substring(0, 2).ToLower()))
				{
					index = 2;
				}
				TranslateOutput.Text += " " + part.Substring(index) + part.Substring(0, index);
			}
		}
		TranslateOutput.Text = TranslateOutput.Text.TrimEnd();
	}
