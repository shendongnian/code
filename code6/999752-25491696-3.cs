	private void button1_Click(object sender, EventArgs e)
	{
		// Testing the extension method.
		MessageBox.Show(DateTime.Now.ToString("dd.MM.yyyy").ToDate("dd.MM.yyyy").ToString());
	}
