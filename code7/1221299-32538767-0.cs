    public static class VisualToBitmapConverter
    {
        private enum TernaryRasterOperations : uint
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
            CAPTUREBLT = 0x40000000
        }
    
        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);
    
        public static Bitmap GetBitmap(Visual visual, int width, int height)
        {
            IntPtr source;
            IntPtr destination;
    
            Bitmap bitmap = new Bitmap(width, height);
            HwndSource hwndSource = (HwndSource)PresentationSource.FromVisual(visual);
            using (Graphics graphicsFromVisual = Graphics.FromHwnd(hwndSource.Handle))
            {
                using (Graphics graphicsFromImage = Graphics.FromImage(bitmap))
                {
                    source = graphicsFromVisual.GetHdc();
                    destination = graphicsFromImage.GetHdc();
    
                    BitBlt(destination, 0, 0, bitmap.Width, bitmap.Height, source, 0, 0, TernaryRasterOperations.SRCCOPY);
    
                    graphicsFromVisual.ReleaseHdc(source);
                    graphicsFromImage.ReleaseHdc(destination);
                }
            }
    
            return bitmap;
        }
    }
