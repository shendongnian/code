	public void Create()
	{
		SaveFileDialog save = new SaveFileDialog();
		save.FileName = "Report.txt";
		save.Filter = "Text File | *.txt";
		if (save.ShowDialog() == DialogResult.OK)
		{
			StreamWriter writer = new StreamWriter(save.OpenFile());
			for (int i = 0; i < _Reports.Count; i++)
			{
				writer.WriteLine(_Reports[i].ToString());
			}
			writer.Dispose();
			writer.Close();
		}
	}
	
