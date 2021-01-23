    public partial class Form1 : Form
    {
        private Bitmap _originalBitmap;
        private Bitmap _grayScaleBitmap;
        private Bitmap _pictureBoxBitmap;
        //private Brush brush = new SolidBrush(Color.Red);
        private Pen pen = new Pen(Color.Black, 1);
        private Point? _inspectRectStart;
        public Form1()
        {
            InitializeComponent();
            _originalBitmap = (Bitmap)Bitmap.FromFile("lin-png-256x256-Rafael_256x256_png-256x256.png");
            _grayScaleBitmap = MakeGrayscale3(_originalBitmap);
            _pictureBoxBitmap = new Bitmap(_originalBitmap.Width, _originalBitmap.Height);
            DrawImage();
            pictureBox1.Image = _pictureBoxBitmap;
        }
        private static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);
            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
               });
            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();
            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);
            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }
        private void DrawImage()
        {
            using (Graphics g = Graphics.FromImage(_pictureBoxBitmap))
            {
                g.Clear(Color.White); // if the bitmap has transparent parts
                // draw the grayscale image.
                g.DrawImage(_grayScaleBitmap, new Rectangle(0, 0, _originalBitmap.Width, _originalBitmap.Height), 0, 0, _originalBitmap.Width, _originalBitmap.Height, GraphicsUnit.Pixel);
                // if there is a selection, draw it.
                if (_inspectRectStart.HasValue)
                {
                    var rect = new Rectangle(_inspectRectStart.Value, new Size(50, 50));
                    
                    // draw the original bitmap in a rectangle.
                    g.DrawImage(_originalBitmap, _inspectRectStart.Value.X, _inspectRectStart.Value.Y, rect, GraphicsUnit.Pixel);
                    g.DrawRectangle(pen, rect);
                }
            }
            pictureBox1.Refresh();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // move the rectangle position
            _inspectRectStart = e.Location;
            // redraw image.
            DrawImage();
        }
    }
