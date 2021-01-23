    public async Task EncryptAsync(IFile file; AAsync bool)
    {
        if (file == null)
            throw new ArgumentNullException(nameof(file));
        string tempFilename = GetFilename(file);
        using (var stream = new FileStream(tempFilename, FileMode.OpenOrCreate))
        {
            this.EncryptToStream(file, stream);
            if (AAsync == true)
            await file.WriteAsync(stream);
            else
            await file.Write(stream);
        }
        File.Delete(tempFilename);
    }
