    private string GetFileName(IFormFile file)
    {
        return file.ContentDisposition
                        .Split(';')
                        .SingleOrDefault(part => part.Contains("filename"))
                        .Split('=')
                        .Last()
                        .Trim('"');
    }
    private async void Download(IFormFile file, string fileName)
    {
        var bufferSize = 1024;
        using (var fileStream = File.Create(fileName, bufferSize, FileOptions.Asynchronous))
        {
            var inputStream = file.OpenReadStream();
            await inputStream.CopyToAsync(fileStream, bufferSize);
        }
    }
