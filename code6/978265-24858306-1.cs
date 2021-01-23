    label4.BackColor = Color.Green;
    foreach (string item in listBox2.Items)
	{
		if (processes.Any(x => x.ProcessName == item))
			listBox1.Items.Add(item);
		else
			label4.BackColor = Color.Red;
	}
