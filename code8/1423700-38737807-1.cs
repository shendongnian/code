    class Program
    {
    
        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);
        private static Screen SavedScreen { get; } = Screen.PrimaryScreen;
    
        private static BitmapSource CopyScreen()
        {
            //try
            //{
            BitmapSource result;
            using (
                var screenBmp = new Bitmap(200, 100))
            {
                using (Graphics bmpGraphics = Graphics.FromImage(screenBmp))
                {
                    bmpGraphics.CopyFromScreen(SavedScreen.Bounds.X, SavedScreen.Bounds.Y, 0, 0, screenBmp.Size,
                        CopyPixelOperation.SourceCopy);
                    IntPtr hBitmap = screenBmp.GetHbitmap();
                    bmpGraphics.Dispose();
                    //********** Next line do memory leak
                    result = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    DeleteObject(hBitmap);
                    //result = null;
                    
                }
            }
            GC.Collect();
            return result;
            //}
            //catch (Exception ex)
            //{
            //    //ErrorReporting ($"Error in CopyScreen(): {ex}");
            //    Console.WriteLine(ex.Message);
            //    Debugger.Break();
            //    return null;
            //}
        }
    
        static void Main(string[] args)
        {
            for (int i = 0; i < 100000; i++)
            {
                Thread.Sleep(100);
                var test = CopyScreen();
            }
        }
    }
