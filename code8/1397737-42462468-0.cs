    using System;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.Drawing.Imaging;
    
    namespace StackOverflow.Example.Utility
    {
    
        public class ScreenCapture
        {
            [DllImport("user32.dll")]
            static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);
    
            //Region Flags - The return value specifies the type of the region that the function obtains. It can be one of the following values.
            const int ERROR = 0;
            const int NULLREGION = 1;
            const int SIMPLEREGION = 2;
            const int COMPLEXREGION = 3;
    
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);
    
            [DllImport("gdi32.dll")]
            static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
    
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);
    
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left, Top, Right, Bottom;
    
                public RECT(int left, int top, int right, int bottom)
                {
                    Left = left;
                    Top = top;
                    Right = right;
                    Bottom = bottom;
                }
    
                public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }
    
                public int X
                {
                    get { return Left; }
                    set { Right -= (Left - value); Left = value; }
                }
    
                public int Y
                {
                    get { return Top; }
                    set { Bottom -= (Top - value); Top = value; }
                }
    
                public int Height
                {
                    get { return Bottom - Top; }
                    set { Bottom = value + Top; }
                }
    
                public int Width
                {
                    get { return Right - Left; }
                    set { Right = value + Left; }
                }
    
                public System.Drawing.Point Location
                {
                    get { return new System.Drawing.Point(Left, Top); }
                    set { X = value.X; Y = value.Y; }
                }
    
                public System.Drawing.Size Size
                {
                    get { return new System.Drawing.Size(Width, Height); }
                    set { Width = value.Width; Height = value.Height; }
                }
    
                public static implicit operator System.Drawing.Rectangle(RECT r)
                {
                    return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
                }
    
                public static implicit operator RECT(System.Drawing.Rectangle r)
                {
                    return new RECT(r);
                }
    
                public static bool operator ==(RECT r1, RECT r2)
                {
                    return r1.Equals(r2);
                }
    
                public static bool operator !=(RECT r1, RECT r2)
                {
                    return !r1.Equals(r2);
                }
    
                public bool Equals(RECT r)
                {
                    return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
                }
    
                public override bool Equals(object obj)
                {
                    if (obj is RECT)
                        return Equals((RECT)obj);
                    else if (obj is System.Drawing.Rectangle)
                        return Equals(new RECT((System.Drawing.Rectangle)obj));
                    return false;
                }
    
                public override int GetHashCode()
                {
                    return ((System.Drawing.Rectangle)this).GetHashCode();
                }
    
                public override string ToString()
                {
                    return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
                }
            }
            public Bitmap GetScreenshot(IntPtr ihandle)
            {
                IntPtr hwnd = ihandle;//handle here
    
                RECT rc;
                GetWindowRect(new HandleRef(null, hwnd), out rc);
    
                Bitmap bmp = new Bitmap(rc.Right - rc.Left, rc.Bottom - rc.Top, PixelFormat.Format32bppArgb);
                Graphics gfxBmp = Graphics.FromImage(bmp);
                IntPtr hdcBitmap;
                try
                {
                    hdcBitmap = gfxBmp.GetHdc();
                }
                catch
                {
                    return null;
                }
                bool succeeded = PrintWindow(hwnd, hdcBitmap, 0);
                gfxBmp.ReleaseHdc(hdcBitmap);
                if (!succeeded)
                {
                    gfxBmp.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(Point.Empty, bmp.Size));
                }
                IntPtr hRgn = CreateRectRgn(0, 0, 0, 0);
                GetWindowRgn(hwnd, hRgn);
                Region region = Region.FromHrgn(hRgn);//err here once
                if (!region.IsEmpty(gfxBmp))
                {
                    gfxBmp.ExcludeClip(region);
                    gfxBmp.Clear(Color.Transparent);
                }
                gfxBmp.Dispose();
                return bmp;
            }
    
            public void WriteBitmapToFile(string filename, Bitmap bitmap)
            {
                bitmap.Save(filename, ImageFormat.Jpeg);
            }
        }
    }
