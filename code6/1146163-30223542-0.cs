	var listAes = Directory.EnumerateFiles(myFolder, "*.*", SearchOption.AllDirectories)
		.Where(s => s.EndsWith(".aes"))
		.Select(f => new FileInfo(f));
    using (var zip = ZipFile.Read(nameOfExistingZip))
    {
		foreach (var additionFile in listAes)
		{
			zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
			zip.AddFile(additionFile.FullName);
		}
		zip.Save();
    }
    file.WriteLine("Delay for adding a file  : " + sw.Elapsed.TotalMilliseconds);
    sw.Restart();
