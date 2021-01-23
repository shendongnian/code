    public class AltoTextBox : Control
    {
        int radius = 15;
        public TextBox box = new TextBox();
        GraphicsPath Shape;
        public AltoTextBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            AddTextBox();
            Controls.Add(box);
            BackColor = Color.Transparent;
            ForeColor = Color.DimGray;
            Text = null;
            Font = new Font("Comic Sans MS", 11);
            Size = new Size(135, 33);
            DoubleBuffered = true;
        }
        void AddTextBox()
        {
            box.Size = new Size(Width - 2*radius, Height - 6);
            box.Location = new Point(radius, 3);
            box.BorderStyle = BorderStyle.None;
            box.TextAlign = HorizontalAlignment.Left;
            box.Multiline = true;
            box.Font = Font;
        }
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            box.Text = Text;
        }
        GraphicsPath innerRect;
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            box.Font = Font;
        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Shape = new RoundedRectangleF(Width, Height, radius).Path;
            innerRect = new RoundedRectangleF(Width - 0.5f, Height - 0.5f, radius, 0.5f, 0.5f).Path;
            AddTextBox();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = SmoothingMode.HighQuality;
            grp.DrawPath(Pens.Gray, Shape);
            grp.FillPath(Brushes.White, innerRect);
            e.Graphics.DrawImage((Image)bmp.Clone(), 0, 0);
            base.OnPaint(e);
        }
        
    }
