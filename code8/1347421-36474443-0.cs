    public class MyStreamReference : IRandomAccessStreamReference
    {
        private string path;
    
        public MyStreamReference(string path)
        {
            this.path = path;
        }
    
        public IAsyncOperation<IRandomAccessStreamWithContentType> OpenReadAsync()
            => Open().AsAsyncOperation();
    
        public async Task<IRandomAccessStreamWithContentType> Open()
            => await (await StorageFile.GetFileFromPathAsync(path)).OpenReadAsync();
    }
