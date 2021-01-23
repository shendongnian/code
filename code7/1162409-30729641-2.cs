    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
     WriteableBitmap writeableBitmap = new WriteableBitmap(1280, 1024, 96.0, 96.0, PixelFormats.Bgr24, null);
            public MainWindow()
            {
                InitializeComponent();
    
                ImageTarget.Source = writeableBitmap;
    
                Messenger.Default.Register<Bitmap>(this, (bmp) =>
                {
                    ImageTarget.Dispatcher.BeginInvoke((Action)(() =>
                   {
                        BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
                        writeableBitmap.Lock();
                        CopyMemory(writeableBitmap.BackBuffer, data.Scan0,
                            (writeableBitmap.BackBufferStride * bmp.Height));
                        writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, bmp.Width, bmp.Height));
                        writeableBitmap.Unlock();
                        bmp.UnlockBits(data);
                    }));
                });
            }
