      public sealed partial class Form1 : Form
      {
        private readonly Bitmap m_BlueBox;
        private readonly Bitmap m_YellowBox;
    
        public Form1()
        {
          InitializeComponent();
          DoubleBuffered = true;
          m_YellowBox = CreateBox(Color.Yellow);
          m_BlueBox = CreateBox(Color.Blue);
          m_BlueBox = ChangeOpacity(m_BlueBox, 0.5f);
        }
    
        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
          var bmp = new Bitmap(img.Width, img.Height);
          using (var graphics = Graphics.FromImage(bmp))
          {
            var colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            var imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height,
              GraphicsUnit.Pixel, imgAttribute);
          }
          return bmp;
        }
    
        private static Bitmap CreateBox(Color color)
        {
          var bmp = new Bitmap(200, 200);
          for (var x = 0; x < bmp.Width; x++)
          {
            for (var y = 0; y < bmp.Height; y++)
            {
              bmp.SetPixel(x, y, color);
            }
          }
          return bmp;
        }
    
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          e.Graphics.DrawImage(m_YellowBox, new Point(10, 10));
          e.Graphics.DrawImage(m_BlueBox, new Point(70, 70));
        }
      }
