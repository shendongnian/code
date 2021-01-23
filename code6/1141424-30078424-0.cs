    public void UploadChunk ( RemoteFileChunk file )
    {
        using ( var targetStream = new FileStream("some-path", FileMode.OpenOrCreate, FileAccess.Append, FileShare.None) )
        {
            try
            {
                file.Stream.CopyTo(targetStream);
            }
            finally
            {
                file.Stream.Close();
            }
        }
    }
