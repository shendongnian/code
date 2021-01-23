        public Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var ratio2 = Math.Max(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio2);
            var newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
            newImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            Graphics grPhoto = Graphics.FromImage(newImage);
            grPhoto.InterpolationMode = InterpolationMode.High;
            grPhoto.DrawImage(image, 0, 0, newWidth, newHeight);
            grPhoto.Dispose();
            return newImage;           
        }
