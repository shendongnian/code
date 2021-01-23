    List<Task<Object>> taskList;
    private static readonly object _syncLock = new object();
    public Task<Object> LoadImage(String imageID)
    {
        return Task<Object>.Factory.StartNew(() =>
        {
            lock (_syncLock)
            {
                return LoadImageInternal(imageID).Result;
            }
        });
    }
    private async Task<Object> LoadImageInternal(String imageID)
    {
        //Business Logic for image retrieval.
    }
