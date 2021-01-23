        public static Image ScaleDownTo(Image image, int height, int width) {
            if (image != null) {
                if (image.Width > width || image.Height > height) {
                    float factor = Math.Max(((float)width) / image.Width, ((float)height) / image.Height);
                    if (factor > 0) {
                        RectangleF imgRect = new RectangleF(0, 0, image.Width * factor, image.Height * factor);
                        imgRect.X = ((float)width - imgRect.Width) / 2f;
                        imgRect.Y = ((float)height - imgRect.Height) / 2f;
                        Bitmap cellImage = new Bitmap(width, height);
                        using (Graphics cellImageGraphics = Graphics.FromImage(cellImage)) {
                            cellImageGraphics.Clear(Color.Transparent);
                            cellImageGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            cellImageGraphics.DrawImage(image, imgRect);
                        }
                        return cellImage;
                    }
                }
                return image;
            }
            return null;
        }
