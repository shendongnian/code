    namespace CursorTest
    {
      public struct IconInfo
      {
        public bool fIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
      }
    
      public class CursorTest : Form
      {
        public CursorTest()
        {
          this.Text = "Cursor Test";
    
          Bitmap bitmap = new Bitmap(140, 25);
          Graphics g = Graphics.FromImage(bitmap);
          using (Font f = new Font(FontFamily.GenericSansSerif, 10))
            g.DrawString("{ } Switch On The Code", f, Brushes.Green, 0, 0);
    
          this.Cursor = CreateCursor(bitmap, 3, 3);
    
          bitmap.Dispose();
        }
    
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);
    
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
    
        public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
        {
          IconInfo tmp = new IconInfo();
          GetIconInfo(bmp.GetHicon(), ref tmp);
          tmp.xHotspot = xHotSpot;
          tmp.yHotspot = yHotSpot;
          tmp.fIcon = false;
          return new Cursor(CreateIconIndirect(ref tmp));
        }
      }
    }
