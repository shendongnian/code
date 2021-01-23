    private void ListView1_MouseDown(object sender, MouseEventArgs e)
	{
		ListViewItem selection = ListView1.GetItemAt(e.X, e.Y);
		// If the user selects an item in the ListView, display 
		// the image in the PictureBox. 
		if (selection != null)
		{
			PictureBox1.Image = System.Drawing.Image.FromFile(
				selection.SubItems[1].Text);
		}
	}
