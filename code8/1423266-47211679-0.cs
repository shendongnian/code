    public static void ReplacePngsWithJpegs(Package package)
    {
        // We're modifying the enumerable as we iterate, so take a snapshot with ToList()
        foreach (var part in package.GetParts().ToList())
        {
            if (part.ContentType == "image/png")
            {
                using (var jpegStream = new MemoryStream())
                using (var image = System.Drawing.Image.FromStream(part.GetStream()))
                {
                    image.Save(jpegStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    jpegStream.Seek(0, SeekOrigin.Begin);
                    // Cannot access Uri after part is removed, so store it
                    var uri = part.Uri; 
                    package.DeletePart(uri);
                    var jpegPart = package.CreatePart(uri, "image/jpeg");
                    jpegStream.CopyTo(jpegPart.GetStream());
                }
            }
        }
    }
