    IArchive rar = SharpCompress.Archive.Rar.RarArchive.Open(new FileInfo("ze.rar"), SharpCompress.Common.Options.None);
    string directory = Path.Combine(Directory.GetCurrentDirectory(), "DATA");
    // Calculate the total extraction size.
    double totalSize = rar.Entries.Where(e => !e.IsDirectory).Sum(e => e.Size);
    long completed = 0;
    // Use the same logic for extracting each file like IArchive.WriteToDirectory extension.
    foreach (var entry in rar.Entries.Where(e => !e.IsDirectory))
    {
        entry.WriteToDirectory(directory, ExtractOptions.Overwrite);
        // Track each individual extraction.
        completed += entry.Size;
        var percentage = completed / totalSize;
        // TODO do something with percentage.
    }
