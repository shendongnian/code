    public static Image ApplyWatermark(HttpPostedFileBase img, string appDataPath)
    {
        Image resultImage = null;
        using (Image image = Image.FromStream(img.InputStream))
        {
            using (Image watermarkImage = Image.FromFile(appDataPath + "\\Watermark\\sample-watermark.png"))
            {
                using (Graphics imageGraphics = Graphics.FromImage(image))
                {
                    using (Brush watermarkBrush = new TextureBrush(watermarkImage))
                    {
                        imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(0, 0), image.Size));
                        resultImage = (Image)image.Clone();
                    }
                }
            }
        }
        return resultImage;
    }
    private void SaveImagesOnDisk(IEnumerable<HttpPostedFileBase> images, int rentalPropertyId)
        {
            if (images != null)
            {
                foreach (var file in images)
                {
                    // Some browsers send file names with full path. This needs to be stripped.
                    var fileName = Path.GetFileName(file.FileName);
                    var appDataPath = this.Server.MapPath("~/App_Data/");
                    var newPath = Path.Combine(appDataPath, rentalPropertyId.ToString());
                    if (!Directory.Exists(newPath))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(newPath);
                    }
                    var physicalPath = Path.Combine(newPath, fileName);
                    System.Drawing.Image markedImage = Helper.ApplyWatermark(file, appDataPath);
                    markedImage.Save(physicalPath, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            //return this.Json(new { status = "OK" }, "text/plain");
        }
