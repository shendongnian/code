        public class LabelWithLine : Label
        {
            private Color lineColor;
            private DashStyle dashStyle;
            private bool isLineVisible;
            /// <summary>
            ///set browseable and group by category in propery browser
            /// </summary>
            [Browsable(true)]
            [Category("Line")]
            public Color LineColor 
            { 
                get { return lineColor; } 
                set { lineColor = value; this.Invalidate(); } 
            }
    
            [Browsable(true)]
            [Category("Line")]
            public DashStyle DashStyle { get{return dashStyle;}
                set { dashStyle = value; this.Invalidate(); }
            }
            [Browsable(true)]
            [Category("Line")]
            public bool IsLineVisible { get{return isLineVisible;}
                set { isLineVisible = value; this.Invalidate(); }
            }
          
            public LabelWithLine()
            {
                lineColor = Color.Black;
                dashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                isLineVisible = true;
             
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                if (isLineVisible)
                {
                    Pen p = new Pen(LineColor);
                    p.DashStyle =   this.DashStyle;
                    e.Graphics.DrawLine(p, 0, 0, this.Width, 0);
                }
            }
        }
