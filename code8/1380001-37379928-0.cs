	public static           List<Texture2D>     Textures(string folderPath)
	{
		if (!folderPath.StartsWith(@"\")) folderPath = @"\" + folderPath;
		List<string> paths = Directory.GetFiles(Help.RootDir(Content.RootDirectory) + folderPath).ToList();
		List<Texture2D> images = new List<Texture2D>();
		foreach (string s in paths)
		{
			if (s.EndsWith(".xnb"))
				images.Add(Texture(s.Replace(Content.RootDirectory, "").Replace(".xnb", "")));
		}
		return images;
	}
The folderPath variable should be path from content's folder (without it) to te folder you want to load all textures/songs from. In your case, pass "Songs\\Songs0" as a parameter, replace *Texture2D* to *Song* or *SoundEffect*, and it will work fine.
Also, the Help.RootDir is a simple function I made:
    public static string RootDir(string s)
    { return s.Substring(0, s.LastIndexOf(@"\")); }
And also include System.IO;
