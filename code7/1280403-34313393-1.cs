    // Try to decompress the file data.
    byte[] rawData = null;
    
    using (MemoryStream zipStream = new MemoryStream(fileData))
    {
        try
        {
            using (ZipPackage unzipper = ZipPackage.Open(zipStream))
            {
                // The zip package only contains one entry since GeoObject.FileData only contains one shape or POI.
                if (unzipper.ZipPackageEntries.Count > 0)
                {
                    StreamReader reader = new StreamReader(unzipper.ZipPackageEntries[0].OpenInputStream());
                    rawData = System.Text.Encoding.UTF8.GetBytes(reader.ReadToEnd());
                }
            }
        }
        catch (Exception ex)
        {
             // ZipPackage throws an exception of type Exception if the 
             // package is not valid. Handle exception here, e.g. log etc
        }
    }
