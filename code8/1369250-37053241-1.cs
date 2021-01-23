    private static void RenameZipEntries(string file)
    {
    	using (var archive = new ZipArchive(File.Open(file, FileMode.Open, FileAccess.ReadWrite), ZipArchiveMode.Update))
    	{
    		var entries = archive.Entries.ToArray();
    		foreach (var entry in entries)
    		{
    			var newEntry = archive.CreateEntry(entry.Name + ".dat");
    			using (var a = entry.Open())
    			using (var b = newEntry.Open())
    				a.CopyTo(b);
    			entry.Delete();
    		}
    	}
    }
