    private void getPicture()
     {
          string location = FileUpload1.PostedFile.FileName;
          resizeAndConvertToBase64(location, 100,100);
     }
     protected string resizeAndConvertToBase64(string imageDirectory, int newWidth, int newHeight)
        {
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            System.Drawing.Image srcImage = imageDirectory;
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
            }
            MemoryStream ms = new MemoryStream();
            newImage.Save(ms, ImageFormat.Gif);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            return "data:image/gif;base64," + base64Data;
        }
