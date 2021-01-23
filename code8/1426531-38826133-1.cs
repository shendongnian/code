	var fileName = "MyAssetBasedFile.txt";
	if (!File.Exists(Path.Combine(CacheDir.Path, fileName)))
	{
		AssetManager assets = this.Assets;
		using (StreamReader sr = new StreamReader(assets.Open(fileName)))
		using (StreamWriter sw = new StreamWriter(Path.Combine(CacheDir.Path, fileName), append: false))
			sw.Write(sr.ReadToEnd());
	}
	string content;
	using (StreamReader sr = new StreamReader(Path.Combine(CacheDir.Path, fileName)))
	{
		content = sr.ReadToEnd();
	}
	Log.Debug("SO", content);
