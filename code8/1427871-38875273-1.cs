    private int ResizeMethod(FileUpload upload, int iFileCnt)
    {
        Stream strm = upload.PostedFile.InputStream;
        using (var image = System.Drawing.Image.FromStream(strm))
        {
            int newWidth = 450;
            int newHeight = 350;
            var thumbImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imgRectangle);
            string extension = Path.GetExtension(upload.PostedFile.FileName);
            string targetPath = Server.MapPath("\\public\\images\\" + upload.FileName.ToString());
            thumbImg.Save(targetPath, image.RawFormat);
            iFileCnt += 1;
        }
        return iFileCnt;
    }
