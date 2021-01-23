        [DllImport("Kernel32.dll", EntryPoint = "CopyMemory")]
        private static extern void CopyMemory(IntPtr destination, IntPtr source, uint length);
        /// <summary>
        /// loads image fast but UNSAFE
        /// </summary>
        /// <param name="iPath"></param>
        /// <returns></returns>
        public static Image ImageFromFileFast(string iPath)
        {
            using (Bitmap sourceImage = (Bitmap)Image.FromFile(iPath))
            {
                Bitmap targetImage = new Bitmap(sourceImage.Width, sourceImage.Height, sourceImage.PixelFormat);
                BitmapData sourceBitmapData = sourceImage.LockBits(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), ImageLockMode.ReadOnly, sourceImage.PixelFormat);
                BitmapData targetBitmapData = targetImage.LockBits(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), ImageLockMode.WriteOnly, targetImage.PixelFormat);
                CopyMemory(targetBitmapData.Scan0, sourceBitmapData.Scan0, Convert.ToUInt32(sourceBitmapData.Stride) * Convert.ToUInt32(sourceBitmapData.Height));
                sourceImage.UnlockBits(sourceBitmapData);
                targetImage.UnlockBits(targetBitmapData);
                return targetImage;
            }
        }
        public static Image ImageFromFileSlow(string iPath)
        {
            using (Bitmap sourceImage = (Bitmap)Image.FromFile(iPath))
            {
                Bitmap targetImage = new Bitmap(sourceImage.Width, sourceImage.Height, sourceImage.PixelFormat);
                using (Graphics g = Graphics.FromImage(targetImage))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.DrawImage(sourceImage, 0, 0, sourceImage.Width, sourceImage.Height);
                }
                return targetImage;
            }
        }
