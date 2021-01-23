     public static class VisualRender
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
            var topLeft = uiElement.PointToScreen(new System.Windows.Point(0, 0));
            var bottomRight = uiElement.PointToScreen(new System.Windows.Point(uiElement.RenderSize.Width, uiElement.RenderSize.Height));
            var helperWindowLocation = Rect.Empty;
            helperWindowLocation.Union(topLeft);
            helperWindowLocation.Union(bottomRight);
            var width = helperWindowLocation.Width;
            var height = helperWindowLocation.Height;
            //
            var windowsScaleTransform = uiElement.GetWindowsScaleTransform();
            helperWindowLocation.X /= windowsScaleTransform;
            helperWindowLocation.Y /= windowsScaleTransform;
            helperWindowLocation.Width /= windowsScaleTransform;
            helperWindowLocation.Height /= windowsScaleTransform;
            BitmapSource bitmapSourceT = await RenderAsync(brush, helperWindowLocation, new System.Windows.Size(width, height));
            bitmapSourceT.Freeze();
            return bitmapSourceT;
        }
        private static async Task<BitmapSource> RenderAsync(System.Windows.Media.Brush brush, Rect helperWindowLocation, System.Windows.Size snapshotSize)
        {
            // Create a tmp window with its own hwnd to render it later
            var window = new Window { WindowStyle = WindowStyle.None, ResizeMode = ResizeMode.NoResize, ShowInTaskbar = false, Background = System.Windows.Media.Brushes.White };
            window.Left = helperWindowLocation.X;
            window.Top = helperWindowLocation.Y;
            window.Width = helperWindowLocation.Width;
            window.Height = helperWindowLocation.Height;
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
                (int)snapshotSize.Width, (int)snapshotSize.Height);
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
        public static double GetWindowsScaleTransform(this Visual visual)
        {
            Matrix m = Matrix.Identity;
            var presentationSource = PresentationSource.FromVisual(visual);
            if (presentationSource != null)
            {
                if (presentationSource.CompositionTarget != null) m = presentationSource.CompositionTarget.TransformToDevice;
            }
            double totalTransform = m.M11;
            return totalTransform;
        }
    }
