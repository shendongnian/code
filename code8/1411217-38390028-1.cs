    public class MyRadioButton : RadioButton
    {
        public MyRadioButton()
        {
            this.Appearance = System.Windows.Forms.Appearance.Button;
            this.BackColor = Color.Transparent;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlatAppearance.BorderColor = Color.RoyalBlue;
            this.FlatAppearance.BorderSize = 2;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.OnPaintBackground(e);
            using (var path = new GraphicsPath())
            {
                var c = e.Graphics.ClipBounds;
                var r = this.ClientRectangle;
                r.Inflate(-FlatAppearance.BorderSize, -FlatAppearance.BorderSize);
                path.AddEllipse(r);
                e.Graphics.SetClip(path);
                base.OnPaint(e);
                e.Graphics.SetClip(c);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if (this.Checked)
                {
                    using (var p = new Pen(FlatAppearance.BorderColor, 
                                           FlatAppearance.BorderSize))
                    {
                        e.Graphics.DrawEllipse(p, r);
                    }
                }
            }
        }
    }
