	var desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
	for (int i = 1; i < 17; i++)
	{
		var folder_path = System.IO.Path.Combine(desktop_path, String.Format(@"xx\Test{0:d2}", i));
		var file_path = System.IO.Path.Combine(folder_path, "file.txt");
		System.IO.Directory.CreateDirectory(folder_path);
		System.IO.File.WriteAllText(file_path, "content");
	}
