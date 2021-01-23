    public partial class Form1 : Form
    {
        private Rectangle _SelectedArea;
        public Form1()
        {
            InitializeComponent();
            _SelectedArea = new Rectangle(0, 0, 20, 20);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!e.Handled)
            {
                switch (e.KeyData)
                {
                    case Keys.Down:
                        _SelectedArea.Offset(0, 1);
                        break;
                    case Keys.Up:
                        _SelectedArea.Offset(0, -1);
                        break;
                    case Keys.Left:
                        _SelectedArea.Offset(-1, 0);
                        break;
                    case Keys.Right:
                        _SelectedArea.Offset(1, 0);
                        break;
                }
                e.Handled = true;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(Color.Red))
            using (var brush = new HatchBrush(HatchStyle.Percent10, Color.Blue, Color.Transparent))
            {
                e.Graphics.FillRectangle(brush, _SelectedArea);
                e.Graphics.DrawRectangle(pen, _SelectedArea);
            }
        }
    }
