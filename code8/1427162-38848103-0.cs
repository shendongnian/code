It is because everytime you call SetSelected, SelectedIndexChanged can be called.
This creates an infinite calling of listBox1.SetSelected > listBox1_SelectedIndexChanged > listBox2.SetSelected > listBox2_SelectedIndexChanged > listBox1.SetSelected.
Eventually, the system stops you by a StackOverflowException.
	private bool mirroring = false;
	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (mirroring) return;
		mirroring = true;
		string item = listBox1.SelectedItem.ToString();
		int index = listBox2_Fichiers.FindString(item);
		listBox2.SetSelected(index, true);
		
		mirroring = false;
	}
	private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (mirroring) return;
		mirroring = true;
		string item = listBox2.SelectedItem.ToString();
		int index = listBox1_Fichiers.FindString(item);
		listBox1.SetSelected(index, true);
		mirroring = false;
	}
