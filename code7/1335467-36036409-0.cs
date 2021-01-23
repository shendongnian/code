    public partial class Form1 : Form
    {
        private Point[] _triangle = { new Point(639, 75), new Point(606, 124), new Point(664, 123) };
        private float _angle = 0;
        private Pen _myPen = new Pen(Color.Blue, 1);
        private Pen _myPen2 = new Pen(Color.Red, 1);
        private Point _position = new Point(637, 110);
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPolygon(_myPen, _triangle);
            Matrix matrix = new Matrix();
            matrix.Translate(-_position.X, -_position.Y, MatrixOrder.Append);
            matrix.Rotate(_angle, MatrixOrder.Append);
            matrix.Translate(_position.X, _position.Y, MatrixOrder.Append);
            e.Graphics.Transform = matrix;
            e.Graphics.DrawPolygon(_myPen2, _triangle);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(textBox1.Text, NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture.NumberFormat, out _angle);
            panel1.Refresh();
        }
    }
