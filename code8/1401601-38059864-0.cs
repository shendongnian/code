    private void convert_Click(object sender, EventArgs e)
            {
                // Load a bitmap from disk
                Bitmap originalBitmap = new Bitmap(@"..\..\Bitonal-In.tif");
    
                // Display image
                originalImage.Image = originalBitmap;
    
                // Convert bitmap to RGB format for drawing
                Bitmap rgbBitmap = Converter.ConvertToRGB(originalBitmap);
                // Convert image to bitonal for saving to file
                Bitmap bitonalBitmap = Converter.ConvertToBitonal(rgbBitmap);
    
                // Display converted image
                convertedImage.Image = bitonalBitmap;
    
                // Get an ImageCodecInfo object that represents the TIFF codec.
                ImageCodecInfo imageCodecInfo = GetEncoderInfo("image/tiff");
                System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Compression;
                EncoderParameters encoderParameters = new EncoderParameters(1);
    
                // Save the bitmap as a TIFF file with group IV compression.
                EncoderParameter encoderParameter = new EncoderParameter(encoder, (long)EncoderValue.CompressionCCITT4);
                encoderParameters.Param[0] = encoderParameter;
                bitonalBitmap.Save(@"..\..\Bitonal-Out.tif", imageCodecInfo, encoderParameters);
    
            }
    
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    
    namespace BitonalConverter
    {
        public static class Converter
        {
            public static Bitmap ConvertToRGB(Bitmap original)
            {
                Bitmap newImage = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb);
                newImage.SetResolution(original.HorizontalResolution, original.VerticalResolution);
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.DrawImageUnscaled(original, 0, 0);
                }
                return newImage;
            }
    
            public static Bitmap ConvertToBitonal(Bitmap original)
            {
                Bitmap source = null;
    
                // If original bitmap is not already in 32 BPP, ARGB format, then convert
                if (original.PixelFormat != PixelFormat.Format32bppArgb)
                {
                    source = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb);
                    source.SetResolution(original.HorizontalResolution, original.VerticalResolution);
                    using (Graphics g = Graphics.FromImage(source))
                    {
                        g.DrawImageUnscaled(original, 0, 0);
                    }
                }
                else
                {
                    source = original;
                }
    
                // Lock source bitmap in memory
                BitmapData sourceData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
    
                // Copy image data to binary array
                int imageSize = sourceData.Stride * sourceData.Height;
                byte[] sourceBuffer = new byte[imageSize];
                Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, imageSize);
    
                // Unlock source bitmap
                source.UnlockBits(sourceData);
    
                // Create destination bitmap
                Bitmap destination = new Bitmap(source.Width, source.Height, PixelFormat.Format1bppIndexed);
                destination.SetResolution(original.HorizontalResolution, original.VerticalResolution);
    
                // Lock destination bitmap in memory
                BitmapData destinationData = destination.LockBits(new Rectangle(0, 0, destination.Width, destination.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
    
                // Create destination buffer
                imageSize = destinationData.Stride * destinationData.Height;
                byte[] destinationBuffer = new byte[imageSize];
    
                int sourceIndex = 0;
                int destinationIndex = 0;
                int pixelTotal = 0;
                byte destinationValue = 0;
                int pixelValue = 128;
                int height = source.Height;
                int width = source.Width;
                int threshold = 500;
    
                // Iterate lines
                for (int y = 0; y < height; y++)
                {
                    sourceIndex = y * sourceData.Stride;
                    destinationIndex = y * destinationData.Stride;
                    destinationValue = 0;
                    pixelValue = 128;
    
                    // Iterate pixels
                    for (int x = 0; x < width; x++)
                    {
                        // Compute pixel brightness (i.e. total of Red, Green, and Blue values) - Thanks murx
                        //                           B                             G                              R
                        pixelTotal = sourceBuffer[sourceIndex] + sourceBuffer[sourceIndex + 1] + sourceBuffer[sourceIndex + 2];
                        if (pixelTotal > threshold)
                        {
                            destinationValue += (byte)pixelValue;
                        }
                        if (pixelValue == 1)
                        {
                            destinationBuffer[destinationIndex] = destinationValue;
                            destinationIndex++;
                            destinationValue = 0;
                            pixelValue = 128;
                        }
                        else
                        {
                            pixelValue >>= 1;
                        }
                        sourceIndex += 4;
                    }
                    if (pixelValue != 128)
                    {
                        destinationBuffer[destinationIndex] = destinationValue;
                    }
                }
    
                // Copy binary image data to destination bitmap
                Marshal.Copy(destinationBuffer, 0, destinationData.Scan0, imageSize);
    
                // Unlock destination bitmap
                destination.UnlockBits(destinationData);
    
                // Dispose of source if not originally supplied bitmap
                if (source != original)
                {
                    source.Dispose();
                }
    
                // Return
                return destination;
            }
        }
    }
