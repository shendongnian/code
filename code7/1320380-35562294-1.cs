    public async Task CropImages(string directory, int x, int y)
    {
        var loadImage = new TransformBlock<String, MyImage>(LoadImageAsync);
        var cropImage = new TransformBlock<MyImage, MyImage>((image) => Crop(image, x, y),
                                                             new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = 5});
        var saveImage = new ActionBlock(SaveImageAsync);
        
       loadImage.LinkTo(cropImage, new DataflowLinkOptions {PropagateCompletion = true, MaxMessages = 100});
       cropImage.LinkTo(saveImage, new DataflowLinkOptions {PropagateCompletion = true, MaxMessages = 100});
       foreach(var file in Directory.EnumerateFiles(directory, "*.jpg"))
       {
           await loadImage.SendAsync(file);
       }
       loadImage.Complete();
       await saveImage.Completion;
    }
    
    private async Task<MyImage> LoadImageAsync(string fileName)
    {
        byte[] data = await GetDataAsync(fileName);
        return new MyImage(data, fileName);
    }
    
    private MyImage Crop(MyImage image, int x, int y)
    {
        image.Crop(x,y);
        return image;
    }
    
    private async Task SaveImageAsync(MyImage image)
    {
        var fileName = Path.GetFileName(image.FileName);
        var directoryName = Path.GetDirectoryName(image.FileName);
        var newName = Path.Combine(directoryName, "Cropped-" + filename);
        await SaveDataAsync(image.Bytes, newName);
    }
