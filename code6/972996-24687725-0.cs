    public partial class Form1 : Form
    {
        private Point _firstPoint;
        private Point _secondPoint;
        private bool _hasClicked;
        public Form1()
        {
            InitializeComponent();
            _hasClicked = false;
            _firstPoint = new Point();
            _secondPoint = new Point();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            _secondPoint.X = e.X;
            _secondPoint.Y = e.Y;
            pictureEdit1.Refresh();
        }
        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_hasClicked)
            {
                _firstPoint.X = e.X;
                _firstPoint.Y = e.Y;
            }
            
            _hasClicked = !_hasClicked;
            pictureEdit1.Refresh();
        }
        private void pictureEdit1_Paint(object sender, PaintEventArgs e)
        {
            if (_hasClicked)
                e.Graphics.DrawLine(Pens.Red, _firstPoint, _secondPoint);
        }
