    public partial class RectangularShape : UserControl
    {
        public RectangularShape()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Red, ClientRectangle);
        }
    }
