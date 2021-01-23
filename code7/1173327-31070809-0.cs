    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using ZXing;
    using ZXing.QrCode.Internal;
    using ZXing.Rendering;
    
    
    namespace Test
    {
        public partial class Form1 : Form
        {
    
            private string imagePath = @"YourPath";
            private Dictionary<EncodeHintType, object> hints { get; set; }
            private int size = 400;
            public Form1()
            {
                InitializeComponent();
    
                pictureBox1.Image = GenerateQR(size, size, @"https://en.WIKIPEDIA.ORG/");
                pictureBox1.Height = size;
                pictureBox1.Width = size;
    
            }
    
    
            public Bitmap GenerateQR(int width, int height, string text)
            {
                var bw = new BarcodeWriter();
                
                var encOptions = new ZXing.Common.EncodingOptions
                {
                    Width = width,
                    Height = height,
                    Margin = 0,
                    PureBarcode = false
                };
    
                encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
    
                bw.Renderer = new BitmapRenderer();
                bw.Options = encOptions;
                bw.Format = BarcodeFormat.QR_CODE;
                Bitmap bm = bw.Write(text);
                Bitmap overlay = new Bitmap(imagePath);
    
                int deltaHeigth = bm.Height - overlay.Height;
                int deltaWidth = bm.Width - overlay.Width;
    
                Graphics g = Graphics.FromImage(bm);
                g.DrawImage(overlay, new Point(deltaWidth/2,deltaHeigth/2));
                
                return bm;
            }
    
        }
    }
