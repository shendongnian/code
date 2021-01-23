	public BitmapImage GetImageFromSource()
	{
		System.IO.Compression.ZipArchive zi = System.IO.Compression.ZipFile.Open(ZipFileLocation, System.IO.Compression.ZipArchiveMode.Read);
		Stream source = zi.GetEntry(InternalLocation).Open();
		
		BitmapImage img = new BitmapImage();
		img.DownloadCompleted += (s, e) =>
		{
			source.Dispose();
			zi.Dispose();
		};
		img.BeginInit();
		img.CacheOption = BitmapCacheOption.OnLoad;
		img.StreamSource = source;
		img.EndInit();
		return img;
	}
