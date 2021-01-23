        [HttpPost]
        public string UploadOriginalImage(HttpPostedFileBase img)
        {
            string folder = Server.MapPath("~/Images/Temp");
            string extension = Path.GetExtension(img.FileName);
            string pic = Path.GetFileName(Guid.NewGuid().ToString());
            string tempPath = Path.ChangeExtension(pic, extension);
            string tempFilePath = Path.Combine(folder, tempPath);
            img.SaveAs(tempFilePath);
            var image = System.Drawing.Image.FromFile(tempFilePath);
            var result = new
            {
                status = "success",
                width = image.Width,
                height = image.Height,
                url = "../Images/Temp/" + tempPath
            };
            return JsonConvert.SerializeObject(result);
        }
       private string CropImage(string originalFilePath, int origW, int origH,
           int targetW, int targetH, int cropStartY, int cropStartX,
           int cropH, int cropW, double angle)
        {
            var originalImage = Image.FromFile(originalFilePath);
            originalImage = RotateImage(originalImage, (float)angle);
            var resizedOriginalImage = new Bitmap(originalImage, targetW, targetH);
            var targetImage = new Bitmap(cropW, cropH);
            using (var g = Graphics.FromImage(targetImage))
            {
                g.DrawImage(resizedOriginalImage, new Rectangle(0, 0, cropW, cropH),
                            new Rectangle(cropStartX, cropStartY, cropW, cropH),
                            GraphicsUnit.Pixel);
            }
            string fileName = Path.GetFileName(originalFilePath);
            var folder = Server.MapPath("~/Images/Cropped");
            string croppedPath = Path.Combine(folder, fileName);
            targetImage.Save(croppedPath);
            return fileName;
        }
        
        public static Bitmap RotateImage(Image img, float rotationAngle)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, new Point(0, 0));
            gfx.Dispose();
            return bmp;
        }
