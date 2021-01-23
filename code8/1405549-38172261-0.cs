	private void Form1_Load(object sender, EventArgs e)
	{
		ItemHasBeenSelected += Form1_ItemHasBeenSelected;
	}
	private void Form1_ItemHasBeenSelected(object sender, SelectedItemEventArgs e)
	{
		MessageBox.Show("Chosen: " + e.SelectedChoice);
	}
