    public partial class Form1 : Form
    {
        // define triangle points  ('world coords :'-(   ?????????
        private Point[] _triangle = { new Point(639, 75), new Point(606, 124), new Point(664, 123) };
        // cache the angle
        private float _angle = 0;
        // cache the GObjects!!
        private Pen _myPen = new Pen(Color.Blue, 1);
        private Pen _myPen2 = new Pen(Color.Red, 1);
        // The rotation origin position
        private Point _origin = new Point(637, 110);
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // draw the origin triangle
            e.Graphics.DrawPolygon(_myPen, _triangle);
            // create a matrix
            Matrix matrix = new Matrix();
            // first translate the triangle coordinates with the negative origin coords (translate coords to origin coordinate system)
            // This translation is only needed, because your triangle is in world coordinates..
            matrix.Translate(-_origin.X, -_origin.Y, MatrixOrder.Append);
            // do the rotation..
            matrix.Rotate(_angle, MatrixOrder.Append);
            // translate the triangle coordinates back to the 'world' coordinate system
            matrix.Translate(_origin.X, _origin.Y, MatrixOrder.Append);
            // assign the matrix to the Graphics
            e.Graphics.Transform = matrix;
            // Draw the polygon
            e.Graphics.DrawPolygon(_myPen2, _triangle);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(textBox1.Text, NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture.NumberFormat, out _angle);
            panel1.Refresh();
        }
    }
