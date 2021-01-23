    public Stream GetFile(string path) 
    {
        Stream fileStream = null;    
        try   
        {
            fileStream = File.OpenRead(path);
        }
        catch(Exception)
        {
            return null;
        }
        OperationContext clientContext = OperationContext.Current;
        clientContext.OperationCompleted += new EventHandler(delegate(object sender, EventArgs args)
        {
            if (fileStream != null)
                fileStream.Dispose();
        });
        return fileStream;
    }
