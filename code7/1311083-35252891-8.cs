    class ColorCheckBox : CheckBox
    {
        Color ccol = Color.OrangeRed;
        public Color CheckColor { get { return ccol; } set { ccol = value;} }
        public ColorCheckBox()
        {
            Appearance = System.Windows.Forms.Appearance.Button;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            TextAlign = ContentAlignment.MiddleRight;
            FlatAppearance.BorderSize = 0;
            AutoSize = false;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Point pt = new Point(pevent.ClipRectangle.Left + 1, pevent.ClipRectangle.Top + 1);
            Rectangle rect = new Rectangle(pt, new Size(21, 21));
            if (Checked)
            {
                using (SolidBrush brush = new SolidBrush(ccol))
                using (Font wing = new Font("Wingdings", 14f))
                    pevent.Graphics.DrawString("ü", wing, brush, rect);
            }
            pevent.Graphics.DrawRectangle(Pens.DarkSlateBlue, rect);
        }
    }
