      public class PicExt : PictureBox
        {
            private Color _borderColor;
            private int _borderWidth;
            [Browsable(true)]
            public Color BorderColor { 
                get { return _borderColor; } 
                set { _borderColor = value; this.Invalidate(); } 
            }
            [Browsable(true)]
            public int BorderWidth {
                get { return _borderWidth; }
                set { _borderWidth = value; this.Invalidate(); }
            }
           
            public PicExt()
            {
                _borderColor = Color.Red;
                _borderWidth = 3;
                
            }
    
            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);
                pe.Graphics.DrawRectangle(new Pen(BorderColor, BorderWidth), BorderWidth, BorderWidth, this.Size.Width - (BorderWidth*2), this.Size.Height - (BorderWidth*2));
            }
        }
