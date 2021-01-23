    HttpFileCollection uploadFilCol = HttpContext.Current.Request.Files;
    for (int i = 0; i < uploadFilCol.Count; i++)
    {
        HttpPostedFile postedFile = uploadFilCol[i];
        using (var br = new BinaryReader(postedFile.InputStream))
        {
            var imageBytes = br.ReadBytes(postedFile.ContentLength);
            var image = Image.GetInstance(imageBytes);
    
            // still not sure if you want to add a new blank page, but 
            // here's how
            //stamper.InsertPage(
            //    APPEND_NEW_PAGE_NUMBER, reader.GetPageSize(APPEND_NEW_PAGE_NUMBER - 1)
            //);
    
            // image absolute position
            image.SetAbsolutePosition(absoluteX, absoluteY);
                                
            // scale image if needed
            // image.ScaleAbsolute(...);
    
            // PAGE_NUMBER => add image to specific page number
            stamper.GetOverContent(PAGE_NUMBER).AddImage(image);
        }
    }
