	private async void button1_Click(object sender, EventArgs e)
	{
		const int size = 5;
		int[] values = new int[size];
	
		int index = 0;
		string path = "nav.txt";
	
		StreamReader input = File.OpenText(path);
		while (index < values.Length && !input.EndOfStream)
		{
			values[index] = int.Parse(await input.ReadLineAsync());
			index++;
		}
	
		foreach (int value in values)
			listBox1.Items.Add(value);
	}
	
