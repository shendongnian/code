    var images = imageRepository.GetAll(allCountryId);
    using (MemoryStream ms = new MemoryStream())
    {
        using (GZipStream gz = new GZipStream(ms, CompressionMode.Compress, false))
        {
            foreach (var image in images)
            { 
                gz.Write(image.ImageData, 0, image.ImageData.Length);
            }
        }
        return base.File(ms.ToArray(), "application/zip", "SudaAmerica");
    }
