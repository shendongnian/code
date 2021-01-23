        class ImageRotation
        {
    
            Timer _time;
            IReadOnlyList<StorageFile> pictures;
    
            public ImageRotation(Grid targetGrid)
            {
            };
     
            public async Task LoadImages()
            {
               pictures = await scanImagesFolder();
            }
    This will make the `pictures = ` on the same context if you need it. If you don't need that functionality use
            public async Task LoadImages()
            {
               pictures = await scanImagesFolder().ConfigureAwait(false);
            }
