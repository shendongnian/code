        public static BitmapSource ToBitmapSource(IImage image)
        {
            using (System.Drawing.Bitmap source = image.Bitmap)
            {
                IntPtr ptr = source.GetHbitmap(); //obtain the Hbitmap
                long imageSize = image.Size.Height*image.Size.Width*4; // 4 bytes per pixel
                GC.AddMemoryPressure(imageSize);
                BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    ptr,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                    
                DeleteObject(ptr); //release the HBitmap
                GC.RemoveMemoryPressure(imageSize);
                return bs;
            }
        }
