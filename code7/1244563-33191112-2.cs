    public async Task<IBitmap> GetAlbumCoverImage(IAlbum album)
    {
        // ...
        var taskCompletionSource = new TaskCompletionSource<UIImage>(); // create the completion source
        PHImageManager.DefaultManager.RequestImageForAsset(
            asset, 
            new CoreGraphics.CGSize(512, 512), 
            PHImageContentMode.AspectFit, 
            null, 
            (image, info) => taskCompletionSource.SetResult(image)); // set its result
        UIImage image = await taskCompletionSource.Task; // asynchronously wait for the result
        return ConvertUIImageToBitmap(image); // convert it
    }
