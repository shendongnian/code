    class RGB24BitmapSource : BitmapSource
    {
        private byte[] _data;
        private int _stride;
        private int _pixelWidth;
        private int _pixelHeight;
        public RGB24BitmapSource(int pixelWidth, int pixelHeight, IntPtr data, int dataLength, int stride)
        {
            if (dataLength != 0 && data != null && data.ToInt64() != 0)
            {
                _data = new byte[dataLength];
                Marshal.Copy(data, _data, 0, dataLength);
            }
            _stride = stride;
            _pixelWidth = pixelWidth;
            _pixelHeight = pixelHeight;
        }
        private RGB24BitmapSource(int pixelWidth, int pixelHeight, byte[] data, int stride)
        {
            _data = data;
            _stride = stride;
            _pixelWidth = pixelWidth;
            _pixelHeight = pixelHeight;
        }
        unsafe public override void CopyPixels(Int32Rect sourceRect, Array pixels, int stride, int offset)
        {
            if (_data != null)
            {
                fixed (byte* source = _data, destination = (byte[])pixels)
                {
                    byte* dstPtr = destination + offset;
                    for (int y = sourceRect.Y; y < sourceRect.Y + sourceRect.Height; y++)
                    {
                        for (int x = sourceRect.X; x < sourceRect.X + sourceRect.Width; x++)
                        {
                            byte* srcPtr = source + _stride * y + 3 * x;
                            byte a = 255;
                            *(dstPtr++) = (byte)((*(srcPtr + 2)) * a / 256);
                            *(dstPtr++) = (byte)((*(srcPtr + 1)) * a / 256);
                            *(dstPtr++) = (byte)((*(srcPtr + 0)) * a / 256);
                            *(dstPtr++) = a;
                        }
                    }
                }
            }
            _data = null; // it was copied for render, so next GC cycle could theoretically reclaim this memory. This is the magic fix.
        }
        protected override Freezable CreateInstanceCore()
        {
            return new RGB24BitmapSource(_pixelWidth, _pixelHeight, _data, _stride);
        }
        // DO. NOT. COMMENT. THESE. OUT. IF YOU DO, CRASHES HAPPEN!
    #pragma warning disable 0067 // disable unused warnings
        public override event EventHandler<DownloadProgressEventArgs> DownloadProgress;
        public override event EventHandler DownloadCompleted;
        public override event EventHandler<ExceptionEventArgs> DownloadFailed;
        public override event EventHandler<ExceptionEventArgs> DecodeFailed;
    #pragma warning restore 0067
        public override double DpiX
        {
            get { return 96; }
        }
        public override double DpiY
        {
            get { return 96; }
        }
        public override System.Windows.Media.PixelFormat Format
        {
            get { return PixelFormats.Pbgra32; }
        }
        public override BitmapPalette Palette
        {
            get { return BitmapPalettes.WebPalette; }
        }
        public override int PixelWidth
        {
            get { return _pixelWidth; }
        }
        public override int PixelHeight
        {
            get { return _pixelHeight; }
        }
        public override double Width
        {
            get { return _pixelWidth; }
        }
        public override double Height
        {
            get { return _pixelHeight; }
        }
    }
