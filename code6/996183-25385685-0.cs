    /// <summary>
    /// Add a file to the archive.
    /// </summary>
    /// <param name="fileName">The name of the file to add.</param>
    /// <param name="entryName">The name to use for the <see cref="ZipEntry"/> on the Zip file created.</param>
    /// <exception cref="ArgumentNullException">Argument supplied is null.</exception>
    public void Add(string fileName, string entryName)
    {
        if (fileName == null) 
        {
            throw new ArgumentNullException("fileName");
        }
        if ( entryName == null ) 
        {
            throw new ArgumentNullException("entryName");
        }
			
        CheckUpdating();
        AddUpdate(new ZipUpdate(fileName, EntryFactory.MakeFileEntry(fileName, entryName, true)));
    }
