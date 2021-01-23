    public class DrawRectangle
    {
        public Color color { get; set; }
        public float width { get; set; }
        public Color fillColor { get; set; }
        public Rectangle rect { get; set; }
        public Control surface { get; set; }
        public DrawRectangle(Rectangle r, Color c, float w, Color fill, Control ct  )
        {
            color = c;
            width = w;
            fillColor = fill;
            rect = r;
            surface = ct;
        }
        public DrawRectangle(Rectangle r, Color c, float w,  Control ct) 
        : this. DrawRectangle(r, c, w, Color.Empty, ct)  {}
        public override string ToString()
        {
            return rect.ToString() + " (" + color.ToString() + 
                   " - " + width.ToString("0.00") + ")";
        }
        public void Draw(Graphics g)
        {
            if (fillColor != Color.Empty) 
                using (SolidBrush brush = new SolidBrush(fillColor))
                     g.FillRectangle(brush, rect);
            if (color != Color.Empty)
                using (Pen pen = new Pen(color, width)) g.DrawRectangle(pen, rect);
        }
    }
