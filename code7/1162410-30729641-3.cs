    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
    private WriteableBitmap _writeable = new WriteableBitmap(1280, 1024, 96.0, 96.0, PixelFormats.Bgr24, null);
            
    public MainWindow()
    {
        InitializeComponent();
    
        ImageTarget.Source = _writeable;
    
        Messenger.Default.Register<Bitmap>(this, (bmp) =>
        {
            ImageTarget.Dispatcher.BeginInvoke((Action)(() =>
            {
                var data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
                _writeable.Lock();
                CopyMemory(_writeable.BackBuffer, data.Scan0,(_writeable.BackBufferStride * bmp.Height));
                
                _writeable.AddDirtyRect(new Int32Rect(0, 0, bmp.Width, bmp.Height));
                _writeable.Unlock();
                bmp.UnlockBits(data);
            }));
        });
    }
