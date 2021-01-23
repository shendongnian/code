    public void ResizeImage(TargetSize targetSize, ResizeMultiplier multiplier, Stream input, Stream output)
    {
        using (var image = Image.FromStream(input))
        {
            // Calculate the resize factor
            var scaleFactor = targetSize.CalculateScaleFactor(image.Width, image.Height);
            scaleFactor /= (int)multiplier; 
            var newWidth = (int)Math.Floor(image.Width / scaleFactor);
            var newHeight = (int)Math.Floor(image.Height / scaleFactor);
            using (var newBitmap = new Bitmap(newWidth, newHeight))
            {
                using (var imageScaler = Graphics.FromImage(newBitmap))
                {
                    imageScaler.CompositingQuality = CompositingQuality.HighQuality;
                    imageScaler.SmoothingMode = SmoothingMode.HighQuality;
                    imageScaler.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                    imageScaler.DrawImage(image, imageRectangle);
                    // Fix orientation if needed.
                    if (image.PropertyIdList.Contains(OrientationKey))
                    {
                        var orientation = (int)image.GetPropertyItem(OrientationKey).Value[0];
                        switch (orientation)
                        {
                            case NotSpecified: // Assume it is good.
                            case NormalOrientation:
                                // No rotation required.
                                break;
                            case MirrorHorizontal:
                                newBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                break;
                            case UpsideDown:
                                newBitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                break;
                            case MirrorVertical:
                                newBitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                                break;
                            case MirrorHorizontalAndRotateRight:
                                newBitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
                                break;
                            case RotateLeft:
                                newBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                break;
                            case MirorHorizontalAndRotateLeft:
                                newBitmap.RotateFlip(RotateFlipType.Rotate270FlipX);
                                break;
                            case RotateRight:
                                newBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                break;
                            default:
                                throw new NotImplementedException("An orientation of " + orientation + " isn't implemented.");
                        }
                    }
                    newBitmap.Save(output, image.RawFormat);
                }
            }
        }
    }
