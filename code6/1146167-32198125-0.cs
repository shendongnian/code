    var listAes = Directory.EnumerateFiles(myFolder, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".aes")).Select(f => new FileInfo(f));
    
    foreach (var additionFile in listAes)
    {
        // (1)
        using (var zip = ZipFile.Read(nameOfExistingZip))
        {
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
            // (2)
            zip.AddFile(additionFile.FullName);
    
            // (3)
            zip.Save();
        }
    
        file.WriteLine("Delay for adding a file  : " + sw.Elapsed.TotalMilliseconds);
        sw.Restart();
    }
