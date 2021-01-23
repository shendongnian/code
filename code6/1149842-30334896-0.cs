    private void control_MouseDown(object sender, MouseEventArgs e)
	{
		List<string> stringItems = new List<string>() { "Value1", "Value2", "Value3" };
		//Separate all values with tabs
		string someValues = string.Join("\t", stringItems);
		DataObject data = new DataObject(DataFormats.Text, someValues);
		DoDragDrop(data, DragDropEffects.Copy);
	}
