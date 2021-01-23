	private void button6_Click(object sender, EventArgs e)
	{
		string copyPath = @"C:\user\elec\copy";
		if (!System.IO.Directory.Exists(copyPath))
			System.IO.Directory.CreateDirectory(copyPath);
		for (int i = 0; i < dataGridView1.Rows.Count; i++)
		{
			if (dataGridView1.Rows[i].Cells[0].Value != null && 
				!String.IsNullOrEmpty(dataGridView1.Rows[i].Cells[0].Value.ToString()))
			{
				string filePath = dataGridView1.Rows[i].Cells[0].Value.ToString();
				if (System.IO.File.Exists(filePath))
				{
					dataGridView1.Rows[i].Cells[1].Value = filePath;
					string fileName = System.IO.Path.GetFileName(filePath);
					string newpath = System.IO.Path.Combine(copyPath, fileName);
					System.IO.File.Copy(filePath, newpath, true);
				}
				dataGridView1.Rows[i].Cells[0].Value = string.Empty;
			}
		}
	}
