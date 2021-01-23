    public class LinePanel : Panel
    {
        public LinePanel()
        {
            this.MouseDown += (src, e) => { LineStartPos = LineEndPos = e.Location; Capture = true; Invalidate(); };
            this.MouseMove += (src, e) => { if (Capture) { LineEndPos = e.Location; Invalidate(); } };
            this.MouseUp += (src, e) => { if (Capture) { LineEndPos = e.Location; } Capture = false; Invalidate(); };
        }
        private Point LineStartPos, LineEndPos;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (LineStartPos != LineEndPos)
                e.Graphics.DrawLine(new Pen(Color.Black, 2), LineStartPos, LineEndPos);
        }
    }
