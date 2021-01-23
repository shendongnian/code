    private static SemaphoreSlim _thread= new SemaphoreSlim(1);    
    public static async Task WriteTextAsync(string filePath, string text)
    {
        byte[] encodedText = Encoding.Unicode.GetBytes(text);
        await _sync.WaitAsync();
        try
        {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.ReadWrite,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
        finally
        {
            _thread.Release();
        }
    }
