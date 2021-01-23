    private async Task EncryptAsync(IFile file, bool sync)
    {
      if (file == null)
        throw new ArgumentNullException(nameof(file));
      string tempFilename = GetFilename(file);
      using (var stream = new FileStream(tempFilename, FileMode.OpenOrCreate))
      {
        this.EncryptToStream(file, stream);
        if (sync)
          file.Write(stream);
        else
          await file.WriteAsync(stream);
      }
      File.Delete(tempFilename);
    }
    public void Encrypt(IFile file)
    {
      EncryptAsync(file, sync: true).GetAwaiter().GetResult();
    }
    public Task EncryptAsync(IFile file)
    {
      return EncryptAsync(file, sync: false);
    }
