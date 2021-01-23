    Bitmap bmp = null;
    Bitmap thumbnail = null;
    try
    {
        using (var ms = new MemoryStream(b))
        {
            bmp = new Bitmap(ms);
        }
        Rectangle rect = new Rectangle(5, 5, 10, 10);
        if (bmp.Width > bmp.Height)
            thumbnail = bmp.Clone(rect, bmp.PixelFormat);
        else if (bmp.Height > bmp.Width)
            thumbnail = bmp.Clone(new Rectangle((bmp.Height/2) - (bmp.Width/2), 0, bmp.Width, bmp.Width), bmp.PixelFormat);
        else
            thumbnail = bmp;
        
    
        byte[] bmpArray = new byte[0];
        using (var ms = new MemoryStream())
        {
            finalCrop.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Close();
            bmpArray = ms.ToArray();
        }
        var name = "Thumbnail_" + parentImageName;
        RepositoryFactory.AzureStorageRepository.SaveThumbnail(bmpArray, name, "jpg/image", CurrentUser.UserOrganization.Organization.Id);
        return BaseBlobUrl + "thumbnails/" + name;
    }
    finally
    {
        if(bmp != null)
            bmp.Dispose();
        if(thumbnail != null)
            thumbnail.Dispose(); //If bmp and thumbnail are the same object this is still safe to do.
    }
