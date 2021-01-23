	private void listBox1_MouseDown(object sender, MouseEventArgs e)
	{
		listBox1.DoDragDrop(listBox1.SelectedItems, DragDropEffects.Copy);
	}
	private void listBox2_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetData(typeof (ListBox.SelectedObjectCollection)) != null)
		{
			e.Effect = DragDropEffects.Copy;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}
	private void listBox2_DragDrop(object sender, DragEventArgs e)
	{
		var items = (ListBox.SelectedObjectCollection)e.Data.GetData(typeof (ListBox.SelectedObjectCollection));
		foreach (var item in items)
		{
			listBox2.Items.Add(item);
		}
	}
