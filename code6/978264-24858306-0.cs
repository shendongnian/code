    label4.BackColor = Color.Green; //by default the label color is Green
    foreach (string item in listBox2.Items)
	{
		var processDeleted = true; //and by default we suppose that every process was deleted
		foreach (var process in processes)
		{
			if (process.ProcessName == item)
			{
				listBox1.Items.Add(process.ProcessName);
				processDeleted = false;
			}
		}
		if (processDeleted) label4.BackColor = Color.Red;
	}
