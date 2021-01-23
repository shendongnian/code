	private void textBox1_TextChanged(object sender, EventArgs e)
	{
		if (textBox1.Text.CompareTo("") != 0)
		{
			textBox1.BackColor = Color.White;
		}
		else
		{
			textBox1.BackColor = Color.Red;
		}
	}
	
