    public FileContentResult GetImage(int id, int w, int h)
        {
            Photo photo = context.FindPhotoById(id);
            MemoryStream ms;
            if (photo.PhotoFile != null)
            {
                if (w != 0 && h != 0)
                {
                    ms = new MemoryStream(photo.PhotoFile);
                    Image img = Image.FromStream(ms);
                    var ratio = (double)img.Width / (double)img.Height;
                    var ratioImg = (double)w / (double)h;
                    var newHeight = 0;
                    var newWidth = 0;
                    if (img.Height > img.Width)
                    {
                        newHeight = h;
                        newWidth = (int)(ratio * newHeight);
                    }
                    else
                    {
                        newWidth = w;
                        newHeight = (int)(newWidth / ratio);
                    }
                    var newImage = new Bitmap(newWidth, newHeight);
                    var destRect = new Rectangle(0, 0, newWidth, newHeight);
                    using (var graphics = Graphics.FromImage(newImage))
                    {
                        graphics.CompositingMode = CompositingMode.SourceCopy;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        using (var wrapMode = new ImageAttributes())
                        {
                            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                            graphics.DrawImage(img, destRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
                        }
                    }
                    Bitmap bmp = new Bitmap(newImage);
                    ImageConverter icnv = new ImageConverter();
                    var imgByte = (byte[])icnv.ConvertTo(bmp, typeof(byte[]));
                    return File(imgByte, photo.ImageMimeType);
                }
                else
                {
                    return File(photo.PhotoFile, photo.ImageMimeType);
                }                
            }
            else
            {
                return null;
            }
        }
