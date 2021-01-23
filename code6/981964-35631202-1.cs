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
       [HttpPost]
        public string CroppedImage(FormCollection form)
        {
            string imgUrl = form["imgUrl"];
            int imgInitW = Convert.ToInt32(form["imgInitW"]);
            int imgInitH = Convert.ToInt32(form["imgInitH"]);
            double imgW = Convert.ToDouble(form["imgW"]);
            double imgH = Convert.ToDouble(form["imgH"]);
            int imgY1 = Convert.ToInt32(form["imgY1"]);
            int imgX1 = Convert.ToInt32(form["imgX1"]);
            int cropH = Convert.ToInt32(form["cropH"]);
            int cropW = Convert.ToInt32(form["cropW"]);
            double angulo = Convert.ToDouble(form["rotation"]);
            var originalFilePath = Server.MapPath(imgUrl);
            var fileName = CropImage(originalFilePath, imgInitW, imgInitH,
                            (int)imgW, (int)imgH, imgY1, imgX1, cropH, cropW, angulo);
            var result = new
            {
                status = "success",
                url = "../Images/Cropped/" + fileName
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
