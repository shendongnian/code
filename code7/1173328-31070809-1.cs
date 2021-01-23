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
        private string url = @"https://en.WIKIPEDIA.ORG/";
        private Dictionary<EncodeHintType, object> hints { get; set; }
        private int size = 400;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = GenerateQR(size, size, url);
            pictureBox1.Height = size;
            pictureBox1.Width = size;
            Console.WriteLine(checkQR(new Bitmap(pictureBox1.Image)));
        }
        public bool checkQR(Bitmap QrCode)
        {
            var reader = new BarcodeReader();
            var result = reader.Decode(QrCode);
            if (result == null)
                return false;
            return result.Text == url;
        }
        public Bitmap GenerateQR(int width, int height, string text)
        {
            var bw = new ZXing.BarcodeWriter();
            
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
            bw.Format = ZXing.BarcodeFormat.QR_CODE;
            Bitmap bm = bw.Write(text);
            Bitmap overlay = new Bitmap(imagePath);
            int deltaHeigth = bm.Height - overlay.Height;
            int deltaWidth = bm.Width - overlay.Width;
            Graphics g = Graphics.FromImage(bm);
            g.DrawImage(overlay, new Point(deltaWidth/2,deltaHeigth/2));
            
            return bm;
        }
    }
