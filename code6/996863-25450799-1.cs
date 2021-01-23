    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace StackOverflow25400312
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                var bounds = Screen.PrimaryScreen.Bounds;
                var imagesSize = new Size(bounds.Width * 2 / 3, bounds.Height);
                var left = LoadLeftDoorTransparentPng(imagesSize);
                var right = LoadRightDoorTransparentPng(imagesSize);
    
                // Create a form with same dimension as the screen.
                var form = new OverlayForm(left, right, bounds);
    
                Application.Run(form);
            }
    
            private static Image GenerateImage(GraphicsPath path, Size sz)
            {
                var bitmap = new Bitmap(sz.Width, sz.Height, PixelFormat.Format32bppArgb);
                var graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.Transparent);
                graphics.FillPath(Brushes.Red, path);
    
                return bitmap;
            }
    
            private static Image LoadRightDoorTransparentPng(Size sz)
            {
                int w = sz.Width;
                int h = sz.Height;
    
                var path = new GraphicsPath();
                path.AddLines(new[]
                    {
                        new Point(w / 2, 0),
                        new Point(w, 0),
                        new Point(w, h),
                        new Point(w / 2, h),
                        new Point(0, h / 2),
                    });
    
                // I will generate it by code but you should use Bitmap.FromFile(...)
                return GenerateImage(path, sz);
            }
    
            private static Image LoadLeftDoorTransparentPng(Size sz)
            {
                int w = sz.Width;
                int h = sz.Height;
    
                var path = new GraphicsPath();
                path.AddLines(new[]
                    {
                        new Point(0, 0),
                        new Point(w, 0),
                        new Point(w / 2, h / 2),
                        new Point(w, h),
                        new Point(0, h),
                    });
    
                // I will generate it by code but you should use Bitmap.FromFile(...)
                return GenerateImage(path, sz);
            }
        }
    
        public class OverlayForm : Form
        {
            public const int WS_EX_NOACTIVATE = 0x08000000;
            public const int WS_EX_TOOLWINDOW = 0x00000080;
            public const int WS_EX_TOPMOST = 0x00000008;
            public const int WS_EX_LAYERED = 0x00080000;
            public const int WS_EX_TRANSPARENT = 0x00000020;
    
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hdc);
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);
            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
            [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
            public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
            [DllImport("user32.dll")]
            public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
    
            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst,
               ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pptSrc, uint crKey,
               [In] ref BLENDFUNCTION pblend, uint dwFlags);
    
            public const int ULW_ALPHA = 2;
    
            [StructLayout(LayoutKind.Sequential)]
            public struct SIZE
            {
                public int cx;
                public int cy;
    
                public SIZE(int cx, int cy)
                {
                    this.cx = cx;
                    this.cy = cy;
                }
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public int X;
                public int Y;
    
                public POINT(int x, int y)
                {
                    this.X = x;
                    this.Y = y;
                }
    
                public POINT(System.Drawing.Point pt) : this(pt.X, pt.Y) { }
    
                public static implicit operator System.Drawing.Point(POINT p)
                {
                    return new System.Drawing.Point(p.X, p.Y);
                }
    
                public static implicit operator POINT(System.Drawing.Point p)
                {
                    return new POINT(p.X, p.Y);
                }
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct BLENDFUNCTION
            {
                public byte BlendOp;
                public byte BlendFlags;
                public byte SourceConstantAlpha;
                public byte AlphaFormat;
    
                public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
                {
                    BlendOp = op;
                    BlendFlags = flags;
                    SourceConstantAlpha = alpha;
                    AlphaFormat = format;
                }
            }
    
            public const int AC_SRC_OVER = 0x00;
            public const int AC_SRC_ALPHA = 0x01;
    
            private readonly Image _left;
            private readonly Image _right;
            private readonly Bitmap _backBuffer;
            private readonly Timer _timer;
            private int _offset;
    
            public OverlayForm(Image left, Image right, Rectangle bounds)
            {
                _left = left;
                _right = right;
                _backBuffer = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
                _timer = new Timer();
                _offset = 0;
    
                Bounds = bounds;
    
                FormBorderStyle = FormBorderStyle.None;
                StartPosition = FormStartPosition.Manual;
                ShowInTaskbar = false;
            }
    
            protected override bool ShowWithoutActivation
            {
                get { return true; }
            }
    
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= WS_EX_LAYERED; // This form has to have the WS_EX_LAYERED extended style
                    cp.ExStyle |= WS_EX_TRANSPARENT; // Click through.
                    cp.ExStyle |= WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST;
                    return cp;
                }
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                _timer.Interval = 16;
                _timer.Tick += _timer_Tick;
                _timer.Start();
            }
    
            private void UpdateLayeredWindow()
            {
                using (Graphics g = Graphics.FromImage(_backBuffer))
                {
                    g.Clear(Color.Transparent);
                    g.DrawImage(_left, 0 - _offset, 0);
                    g.DrawImage(_right, Width - _right.Width + _offset, 0);
                    SetBitmap(_backBuffer);
                }
            }
    
            private void SetBitmap(Bitmap bitmap)
            {
                // 1. Create a compatible DC with screen;
                // 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
                // 3. Call the UpdateLayeredWindow.
    
                IntPtr screenDc = GetDC(IntPtr.Zero);
                IntPtr memDc = CreateCompatibleDC(screenDc);
                IntPtr hBitmap = IntPtr.Zero;
                IntPtr oldBitmap = IntPtr.Zero;
    
                try
                {
                    hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
                    oldBitmap = SelectObject(memDc, hBitmap);
    
                    SIZE size = new SIZE(bitmap.Width, bitmap.Height);
                    POINT pointSource = new POINT(0, 0);
                    POINT topPos = new POINT(Left, Top);
                    BLENDFUNCTION blend = new BLENDFUNCTION();
                    blend.BlendOp = AC_SRC_OVER;
                    blend.BlendFlags = 0;
                    blend.SourceConstantAlpha = 255;
                    blend.AlphaFormat = AC_SRC_ALPHA;
    
                    bool fail = UpdateLayeredWindow(this.Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, ULW_ALPHA);
                }
                finally
                {
                    ReleaseDC(IntPtr.Zero, screenDc);
                    if (hBitmap != IntPtr.Zero)
                    {
                        SelectObject(memDc, oldBitmap);
                        DeleteObject(hBitmap);
                    }
                    DeleteDC(memDc);
                }
            }
    
            void _timer_Tick(object sender, EventArgs e)
            {
                int distance = _left.Width - _offset;
    
                // Is animation done?
                if (distance == 0)
                {
                    _timer.Stop();
                    Close();
                    return;
                }
    
                // Step forward.
                // You can replace with any easing function of your choice,
                // but this one works well usually.
                int step = distance / 9;
    
                // Help it a little when the animation is about to end.
                if (step == 0)
                    step = distance;
    
                _offset += step;
    
                UpdateLayeredWindow();
            }
    
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
    
                if (disposing)
                {
                    _left.Dispose();
                    _right.Dispose();
                    _backBuffer.Dispose();
                    _timer.Dispose();
                }
            }
        }
    }
    
