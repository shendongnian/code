        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true)
            {
                using (Bitmap postedImage = new Bitmap(FileUpload1.PostedFile.InputStream))
                {
                    byte [] bin = Common.scaleImage(postedImage, 400, 400, false);
                    Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(bin);
                }
            }
        }
        public static byte[] scaleImage(Image image, int maxWidth, int maxHeight, bool padImage)
        {
            try
            {
                int newWidth;
                int newHeight;
                byte[] returnArray;
                //check if the image needs rotating (eg phone held vertical when taking a picture for example)
                foreach (var prop in image.PropertyItems)
                {
                    if (prop.Id == 0x0112)
                    {
                        int rotateValue = image.GetPropertyItem(prop.Id).Value[0];
                        RotateFlipType flipType = getRotateFlipType(rotateValue);
                        image.RotateFlip(flipType);
                        break;
                    }
                }
                //apply padding if needed
                if (padImage == true)
                {
                    image = applyPaddingToImage(image);
                }
                //check if the with or height of the image exceeds the maximum specified, if so calculate the new dimensions
                if (image.Width > maxWidth || image.Height > maxHeight)
                {
                    var ratioX = (double)maxWidth / image.Width;
                    var ratioY = (double)maxHeight / image.Height;
                    var ratio = Math.Min(ratioX, ratioY);
                    newWidth = (int)(image.Width * ratio);
                    newHeight = (int)(image.Height * ratio);
                }
                else
                {
                    newWidth = image.Width;
                    newHeight = image.Height;
                }
                //start with a new image
                var newImage = new Bitmap(newWidth, newHeight);
                //set the new resolution, 72 is usually good enough for displaying images on monitors
                newImage.SetResolution(72, 72);
                //or use the original resolution
                //newImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                //resize the image
                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                }
                image = newImage;
                //save the image to a memorystream to apply the compression level, higher compression = better quality = bigger images
                using (MemoryStream ms = new MemoryStream())
                {
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 80L);
                    image.Save(ms, getEncoderInfo("image/jpeg"), encoderParameters);
                    //save the stream as byte array
                    returnArray = ms.ToArray();
                }
                //cleanup
                image.Dispose();
                newImage.Dispose();
                return returnArray;
            }
            catch (Exception ex)
            {
                //there was an error: ex.Message
                return null;
            }
        }
        private static ImageCodecInfo getEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType.ToLower() == mimeType.ToLower())
                    return encoders[j];
            }
            return null;
        }
        private static Image applyPaddingToImage(Image image)
        {
            //get the maximum size of the image dimensions
            int maxSize = Math.Max(image.Height, image.Width);
            Size squareSize = new Size(maxSize, maxSize);
            //create a new square image
            Bitmap squareImage = new Bitmap(squareSize.Width, squareSize.Height);
            using (Graphics graphics = Graphics.FromImage(squareImage))
            {
                //fill the new square with a color
                graphics.FillRectangle(Brushes.Red, 0, 0, squareSize.Width, squareSize.Height);
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                //put the original image on top of the new square
                graphics.DrawImage(image, (squareSize.Width / 2) - (image.Width / 2), (squareSize.Height / 2) - (image.Height / 2), image.Width, image.Height);
            }
            return squareImage;
        }
        private static RotateFlipType getRotateFlipType(int rotateValue)
        {
            RotateFlipType flipType = RotateFlipType.RotateNoneFlipNone;
            switch (rotateValue)
            {
                case 1:
                    flipType = RotateFlipType.RotateNoneFlipNone;
                    break;
                case 2:
                    flipType = RotateFlipType.RotateNoneFlipX;
                    break;
                case 3:
                    flipType = RotateFlipType.Rotate180FlipNone;
                    break;
                case 4:
                    flipType = RotateFlipType.Rotate180FlipX;
                    break;
                case 5:
                    flipType = RotateFlipType.Rotate90FlipX;
                    break;
                case 6:
                    flipType = RotateFlipType.Rotate90FlipNone;
                    break;
                case 7:
                    flipType = RotateFlipType.Rotate270FlipX;
                    break;
                case 8:
                    flipType = RotateFlipType.Rotate270FlipNone;
                    break;
                default:
                    flipType = RotateFlipType.RotateNoneFlipNone;
                    break;
            }
            return flipType;
        }
