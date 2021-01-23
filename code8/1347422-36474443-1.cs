    public class MyStreamReference : IRandomAccessStreamReference
    {
        private string path;
    
        public MyStreamReference(string path)
        {
            this.path = path;
        }
    
        public IAsyncOperation<IRandomAccessStreamWithContentType> OpenReadAsync()
            => Open().AsAsyncOperation();
    
        // private async helper task that is necessary if you need to use await.
        private async Task<IRandomAccessStreamWithContentType> Open()
            => await (await StorageFile.GetFileFromPathAsync(path)).OpenReadAsync();
    }
