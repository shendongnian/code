    HttpFileCollection uploadFilCol = HttpContext.Current.Request.Files;
    for (int i = 0; i < uploadFilCol.Count; i++)
    {
        HttpPostedFile postedFile = uploadFilCol[i];
        using (var br = new BinaryReader(postedFile.InputStream))
        {
            var imageBytes = br.ReadBytes(postedFile.ContentLength);
            var image = Image.GetInstance(imageBytes);
            // image absolute position
            image.SetAbsolutePosition(absoluteX, absoluteY);
                                
            // scale image if needed
            // image.ScaleAbsolute(...);
    
            // PAGE_NUMBER => add image to specific page number
            stamper.GetOverContent(PAGE_NUMBER).AddImage(image);
        }
    }
