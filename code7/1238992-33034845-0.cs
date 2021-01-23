    public class CustomPanel : Panel
    {
        private Color _ColorBorder = Color.Lime;
        private Padding _BordersThickness = new Padding(1);
        private Color _HeaderColor = Color.Blue;
        private int _HeaderHeight = 25;
        private int _SeperatorWidth = 1;
        public CustomPanel()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            typeof(Control).GetProperty("ResizeRedraw", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this, true, null);
            typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this, true, null);
            this.Width = 450;
            this.Height = 375;
            this.Padding = _BordersThickness;
            this.BackColor = Color.Red;
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //draw header
            using (SolidBrush brush = new SolidBrush(HeaderColor))
            {
                e.Graphics.FillRectangle(brush, 0, 0, this.Width, _HeaderHeight);
            }
            //draw border
            if (_BordersThickness.Left > 0)
                using (Pen p = new Pen(_ColorBorder, _BordersThickness.Left * 2))
                {
                    e.Graphics.DrawLine(p, 0, 0, 0, this.Height);
                }
            if (_BordersThickness.Top > 0)
                using (Pen p = new Pen(_ColorBorder, _BordersThickness.Top * 2))
                {
                    e.Graphics.DrawLine(p, 0, 0, this.Width, 0);
                }
            if (_BordersThickness.Right > 0)
                using (Pen p = new Pen(_ColorBorder, _BordersThickness.Right * 2))
                {
                    e.Graphics.DrawLine(p, this.Width, 0, this.Width, this.Height);
                }
            if (_BordersThickness.Bottom > 0)
                using (Pen p = new Pen(_ColorBorder, _BordersThickness.Bottom * 2))
                {
                    e.Graphics.DrawLine(p, 0, this.Height, this.Width, this.Height);
                }
            //draw seperator
            if (_SeperatorWidth > 0)
                using (Pen p = new Pen(_ColorBorder, _SeperatorWidth))
                {
                    e.Graphics.DrawLine(p, 0, _HeaderHeight, this.Width, _HeaderHeight);
                }
        }
        public int SeperatorWidth
        {
            get
            {
                return _SeperatorWidth;
            }
            set
            {
                _SeperatorWidth = value;
                this.Invalidate();
            }
        }
        public int HeaderHeight
        {
            get
            {
                return _HeaderHeight;
            }
            set
            {
                _HeaderHeight = value;
                this.Invalidate();
            }
        }
        public Color HeaderColor
        {
            get
            {
                return _HeaderColor;
            }
            set
            {
                _HeaderColor = value;
                this.Invalidate();
            }
        }
        public Color BorderColor
        {
            get
            {
                return _ColorBorder;
            }
            set
            {
                _ColorBorder = value;
                this.Invalidate();
            }
        }
        public Padding BordersThickness
        {
            get
            {
                return _BordersThickness;
            }
            set
            {
                _BordersThickness = value;
                this.Padding = _BordersThickness;
                this.Invalidate();
            }
        }
    }
