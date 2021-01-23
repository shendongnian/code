     public static class VisualRenderer
    {
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
        static readonly IntPtr _HwndBottom = new IntPtr(1);
        const UInt32 _SWP_NOSIZE = 0x0001;
        const UInt32 _SWP_NOMOVE = 0x0002;
        const UInt32 _SWP_NOACTIVATE = 0x0010;
        public static async Task<BitmapSource> RenderAsync(this UIElement uiElement)
        {
            var brush = new VisualBrush(uiElement);
            var topLeft = uiElement.PointToScreen(new Point(0, 0));
            var bottomRight = uiElement.PointToScreen(new Point(uiElement.RenderSize.Width, uiElement.RenderSize.Height));
            var width = bottomRight.X - topLeft.X;
            var height = bottomRight.Y - topLeft.Y;
            var location = new Rect(topLeft.X, topLeft.Y, width, height);
            BitmapSource bitmapSourceT = await RenderAsync(brush, location);
            bitmapSourceT.Freeze();
            return bitmapSourceT;
        }
        public static async Task<BitmapSource> RenderAsync(Brush brush, Rect location)
        {
            // Create a tmp window with its own hwnd to render it later
            var window = new Window { WindowStyle = WindowStyle.None, ResizeMode = ResizeMode.NoResize, ShowInTaskbar = false, Background = System.Windows.Media.Brushes.Transparent };
            window.Left = location.X;
            window.Top = location.Y;
            window.Width = location.Width;
            window.Height = location.Height;
            window.ShowActivated = false;
            var content = new Grid() { Background = brush };
            RenderOptions.SetBitmapScalingMode(content, BitmapScalingMode.HighQuality);
            window.Content = content;
            var handle = new WindowInteropHelper(window).EnsureHandle();
            window.Show();
            // Make sure the tmp window is under our mainwindow to hide it
            SetWindowPos(handle, _HwndBottom, 0, 0, 0, 0, _SWP_NOMOVE | _SWP_NOSIZE | _SWP_NOACTIVATE);
            //Wait for the element to render
            //await popupChild.WaitForLoaded();
            await window.WaitForFullyRendered();
            ////Why we have to wait here fore the visualbrush to finish its lazy rendering Process? 
            //// Todo: It seems like very complex uielements does not finish its rendering process within one renderloop
            //// Check http://stackoverflow.com/questions/2851236/rendertargetbitmap-resourced-visualbrush-incomplete-image
            // Async BitBlt the tmp Window
            var bitmapSourceT = await Task.Run(() =>
            {
                Bitmap bitmap = VisualToBitmapConverter.GetBitmap(handle,
                (int)location.Width, (int)location.Height);
                var bitmapSource = new SharedBitmapSource(bitmap);
                bitmapSource.Freeze();
                return bitmapSource;
            });
            // Close the Window
            window.Close();
            return bitmapSourceT;
        }
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
            public static Bitmap GetBitmap(IntPtr hwnd, int width, int height)
            {
                var bitmap = new Bitmap(width, height);
                using (Graphics graphicsFromVisual = Graphics.FromHwnd(hwnd))
                {
                    using (Graphics graphicsFromImage = Graphics.FromImage(bitmap))
                    {
                        IntPtr source = graphicsFromVisual.GetHdc();
                        IntPtr destination = graphicsFromImage.GetHdc();
                        BitBlt(destination, 0, 0, bitmap.Width, bitmap.Height, source, 0, 0, TernaryRasterOperations.SRCCOPY);
                        graphicsFromVisual.ReleaseHdc(source);
                        graphicsFromImage.ReleaseHdc(destination);
                    }
                }
                return bitmap;
            }
        }
    }
    public class SharedBitmapSource : BitmapSource, IDisposable
    {
        #region Public Properties
        /// <summary>
        /// I made it public so u can reuse it and get the best our of both namespaces
        /// </summary>
        public Bitmap Bitmap { get; private set; }
        public override double DpiX { get { return Bitmap.HorizontalResolution; } }
        public override double DpiY { get { return Bitmap.VerticalResolution; } }
        public override int PixelHeight { get { return Bitmap.Height; } }
        public override int PixelWidth { get { return Bitmap.Width; } }
        public override System.Windows.Media.PixelFormat Format { get { return ConvertPixelFormat(Bitmap.PixelFormat); } }
        public override BitmapPalette Palette { get { return null; } }
        #endregion
        #region Constructor/Destructor
        public SharedBitmapSource(int width, int height, System.Drawing.Imaging.PixelFormat sourceFormat)
            : this(new Bitmap(width, height, sourceFormat)) { }
        public SharedBitmapSource(Bitmap bitmap)
        {
            Bitmap = bitmap;
        }
        // Use C# destructor syntax for finalization code.
        ~SharedBitmapSource()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
        #endregion
        #region Overrides
        public override void CopyPixels(Int32Rect sourceRect, Array pixels, int stride, int offset)
        {
            BitmapData sourceData = Bitmap.LockBits(
            new Rectangle(sourceRect.X, sourceRect.Y, sourceRect.Width, sourceRect.Height),
            ImageLockMode.ReadOnly,
            Bitmap.PixelFormat);
            var length = sourceData.Stride * sourceData.Height;
            if (pixels is byte[])
            {
                var bytes = pixels as byte[];
                Marshal.Copy(sourceData.Scan0, bytes, 0, length);
            }
            Bitmap.UnlockBits(sourceData);
        }
        protected override Freezable CreateInstanceCore()
        {
            return (Freezable)Activator.CreateInstance(GetType());
        }
        #endregion
        #region Public Methods
        public BitmapSource Resize(int newWidth, int newHeight)
        {
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(Bitmap, 0, 0, newWidth, newHeight);
            }
            return new SharedBitmapSource(newImage as Bitmap);
        }
        public new BitmapSource Clone()
        {
            return new SharedBitmapSource(new Bitmap(Bitmap));
        }
        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        #region Protected/Private Methods
        private static System.Windows.Media.PixelFormat ConvertPixelFormat(System.Drawing.Imaging.PixelFormat sourceFormat)
        {
            switch (sourceFormat)
            {
                case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
                    return PixelFormats.Bgr24;
                case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
                    return PixelFormats.Pbgra32;
                case System.Drawing.Imaging.PixelFormat.Format32bppRgb:
                    return PixelFormats.Bgr32;
            }
            return new System.Windows.Media.PixelFormat();
        }
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Bitmap.Dispose();
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                _disposed = true;
            }
        }
        #endregion
    }
    static class Extensions
    {
        public static Task WaitForLoaded(this FrameworkElement element)
        {
            var tcs = new TaskCompletionSource<object>();
            RoutedEventHandler handler = null;
            handler = (s, e) =>
            {
                element.Loaded -= handler;
                tcs.SetResult(null);
            };
            element.Loaded += handler;
            return tcs.Task;
        }
        public static Task WaitForFullyRendered(this Window window)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler handler = null;
            handler = (s, e) =>
            {
                window.ContentRendered -= handler;
                tcs.SetResult(null);
            };
            window.ContentRendered += handler;
            return tcs.Task;
        }
    }
