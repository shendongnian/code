    public class DrawRectangle
    {
        public Color color { get; set; }
        public float width { get; set; }
        public Rectangle rect { get; set; }
        public Control surface { get; set; }
        public DrawRectangle(Rectangle r, Color c, float w, Control ct)
        {
            color = c;
            width = w;
            rect = r;
            surface = ct;
        }
        public override string ToString()
        {
            return rect.ToString() + " (" + color.ToString() + 
                   " - " + width.ToString("0.00") + ") on " + surface.Name;
        }
    }
