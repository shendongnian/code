	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
	    var selectedItemText = (listBox1.SelectedItem ?? "(none)").ToString();
	    MessageBox.Show("Selected: " + selectedItemText);
	}
	private void listBox1_MouseClick(object sender, MouseEventArgs e)
	{
		for (int i = 0; i < listBox1.Items.Count; i++)
		{
			var rectangle = listBox1.GetItemRectangle(i);
			if (rectangle.Contains(e.Location))
			{
				MessageBox.Show("Item " + i);
				return;
			}
		}
		MessageBox.Show("None");
	}
