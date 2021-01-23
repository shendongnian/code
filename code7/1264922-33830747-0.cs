      var tasks = wantedSizes.Select(async (wantedSize, index) =>
      {
        var resize = size.CalculateResize(wantedSize.GetMaxSize());
        var quality = wantedSize.GetQuality();
    
        using (var output = ImageProcessHelper.Process(streams[index], resize, quality))
        {
            var path = await AzureBlobHelper.SaveFileAsync(output, FileType.Image);
            var result = await _db.AddImageAsync(id, wantedSize, imageNumber, path);
            return result;
        }
      }).ToList();
    
      await Task.WhenAll(tasks)
    
      if (!tasks.All(task => task.Result))
          return new ApiResponse(ResponseStatus.Fail);
