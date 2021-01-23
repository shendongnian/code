    public static Drawing.Bitmap GetBitmapFromImageSource(BitmapSource source) {
                int width = source.PixelWidth;
                int height = source.PixelHeight;
                int stride = width * ((source.Format.BitsPerPixel + 7) / 8);
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(height * stride);
                    source.CopyPixels(new Int32Rect(0, 0, width, height), ptr, height * stride, stride);
                    using (var bmp = new Drawing.Bitmap(width, height, stride, Drawing.Imaging.PixelFormat.Format1bppIndexed, ptr)) {
                        return new Drawing.Bitmap(bmp);
                    }
                }
                finally {
                    if (ptr != IntPtr.Zero) {
                        System.Runtime.InteropServices.Marshal.FreeHGlobal(ptr);
                    }
                }
            }
