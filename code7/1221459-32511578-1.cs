    public async Task EncryptAsync(IFile file, bool AAsync)
    {
        if (file == null)
            throw new ArgumentNullException(nameof(file));
        string tempFilename = GetFilename(file);
        using (var stream = new FileStream(tempFilename, FileMode.OpenOrCreate))
        {
            this.EncryptToStream(file, stream);
            if (AAsync)
                await file.WriteAsync(stream);
            else
                file.Write(stream);
        }
        File.Delete(tempFilename);
    }
