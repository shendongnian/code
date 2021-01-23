    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var bitmap1 = new Bitmap(@"..\..\untitled.png");
                var bitmap2 = new Bitmap(256, 256, bitmap1.PixelFormat);
                CopyRegion(bitmap1, new Rectangle(0, 0, 100, 100), bitmap2, new Point(99, 99));
                bitmap2.Save("result.png");
            }
    
            private unsafe void CopyRegion(Bitmap src, Rectangle srcRect, Bitmap tgt, Point tgtPoint)
            {
                // TODO extra checks etc ...
    
                if (src == null) throw new ArgumentNullException(nameof(src));
                if (tgt == null) throw new ArgumentNullException(nameof(tgt));
    
                if (tgt.PixelFormat != src.PixelFormat)
                    throw new ArgumentOutOfRangeException(nameof(tgt));
    
                var tgtRect = new Rectangle(Point.Empty, tgt.Size);
                var rect = new Rectangle(tgtPoint, srcRect.Size);
                if (!tgtRect.Contains(rect))
                    throw new ArgumentOutOfRangeException(nameof(tgtPoint));
    
                var d1 = src.LockBits(srcRect, ImageLockMode.ReadOnly, src.PixelFormat);
                var d2 = tgt.LockBits(tgtRect, ImageLockMode.WriteOnly, tgt.PixelFormat);
    
                int bitsPerPixel;
                switch (src.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        bitsPerPixel = 24;
                        break;
                    case PixelFormat.Format32bppPArgb:
                        bitsPerPixel = 32;
                        break;
                    case PixelFormat.Format32bppRgb:
                        bitsPerPixel = 32;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
    
                var cols = srcRect.Width;
                var rows = srcRect.Height;
                var bytesPerPixel = (bitsPerPixel + 7)/8;
                var bytes = cols*bytesPerPixel;
                var p1 = d1.Scan0;
                var p2 = d2.Scan0;
                var s1 = d1.Stride;
                var s2 = d2.Stride;
                var x1 = srcRect.X;
                var x2 = tgtPoint.X;
                var y1 = srcRect.Y;
                var y2 = tgtPoint.Y;
                for (var y = 0; y < rows; y++)
                {
                    var b1 = (byte*) (p1 + (s1*(y1 + y) + x1*bytesPerPixel));
                    var b2 = (byte*) (p2 + (s2*(y2 + y) + x2*bytesPerPixel));
                    for (var x = 0; x < bytes; x++)
                    {
                        *b2 = *b1;
                        b1++;
                        b2++;
                    }
                }
    
                src.UnlockBits(d1);
                tgt.UnlockBits(d2);
            }
        }
    }
