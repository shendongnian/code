	public static string[] GetFileList(string Directory, string extensions)
	{
		string[] extensionlist = extensions.Split(';');
		var FileList = Directory.EnumerateFiles(Directory)
			.Where(file => extensionlist.Contains(Path.GetExtension(file))).ToArray<string>();
		return FileList;
	}
