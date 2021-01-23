	private void lbTwo_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
			e.Effect = DragDropEffects.Move;
		else
			e.Effect = DragDropEffects.None;
	}
