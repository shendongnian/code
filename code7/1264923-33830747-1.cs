      var tasks = wantedSizes.Select(async (wantedSize, index) =>
      {
        var resize = size.CalculateResize(wantedSize.GetMaxSize());
        var quality = wantedSize.GetQuality();
    
        using (var output = ImageProcessHelper.Process(streams[index], resize, quality))
        {
            var path = await AzureBlobHelper.SaveFileAsync(output, FileType.Image);
            //Double check your documentation, is _db.AddImageAsync thread safe?
            var result = await _db.AddImageAsync(id, wantedSize, imageNumber, path);
            return result;
        }
      }).ToList(); //We run the Select once here to process the .ToList().
    
      await Task.WhenAll(tasks) //This is the first enumeration of the variable "tasks".
    
      if (!tasks.All(task => task.Result)) //This is a 2nd enumeration of the variable.
          return new ApiResponse(ResponseStatus.Fail);
