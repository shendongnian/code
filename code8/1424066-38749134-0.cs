    public abstract class Shape
    {
        public Color FillColor { get; set; }
        public Shape() { FillColor = Color.Blue; }
        protected abstract GraphicsPath GetPath();
        public bool IsVisble(Point p)
        {
            var result = false;
            using (var path = GetPath())
                result = path.IsVisible(p);
            return result;
        }
        public void Draw(Graphics g)
        {
            using (var path = GetPath())
            using (var brush = new SolidBrush(this.FillColor))
                g.FillPath(brush, path);
        }
        public abstract void Move(Point d);
    }
