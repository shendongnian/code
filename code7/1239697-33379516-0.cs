    public static void CreateThumbnailsForNewlyUploadedPNGs(
        [BlobTrigger("files/{name}.{ext}")] Stream input,
        [BlobOutput("files/{name}~25.png")] Stream output,
        string name,
        string ext)
    {
        using (var bitmap = new Bitmap(input))
        {
            bitmap.Save(output, ImageFormat.Png);
        }
    
    }
