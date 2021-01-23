	private void Write(string file, string text)
	{
		if (File.Exists(file))
		{
			using (StreamWriter objWriter = new StreamWriter(file))
			{
				objWriter.Write(text);
			}
		}
		else
		{
			MessageBox.Show("No file named " + file);
		}
	}
	
	private void btnAlpha_Click(object sender, EventArgs e)
	{
		string wholeText = "";
		string copyText = richTextBox1.Text;
		string nonAlpha = @"[^A-Za-z ]+";
		string addSpace = "";
		copyText = Regex.Replace(copyText, nonAlpha, addSpace);
		wholeText = richTextBox1.Text + copyText;
		Write(Second_File, wholeText); // same for the second button
		richTextBox2.Text = wholeText;
	}
