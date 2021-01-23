	private void button1_Click(object sender, EventArgs e)
	{
	    var folderBrowserDialog = new FolderBrowserDialog();
	    var result = folderBrowserDialog.ShowDialog();
	
		var newPath = Path.Combine(folderBrowserDialog.SelectedPath, @"\Test");
		if (!Directory.Exists(newPath))
		{
			System.IO.Directory.CreateDirectory(newPath);
		}
	
		foreach (var file in Directory.EnumerateFiles(folderBrowserDialog.SelectedPath, "*.chunk*", SearchOption.AllDirectories))
		{
			var newFile = Path.Combine(newPath, Path.GetFileName(file) + ".txt");
			var content = File.ReadAllText(file);
			content = String.Join(",", content.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
	        File.WriteAllText(newFile, content);
		}
	}
