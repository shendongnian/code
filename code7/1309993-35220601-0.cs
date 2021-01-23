    class DrawAction
    {
        public char type { get; set; }
        public Rectangle rect { get; set; }
        public Color color { get; set; }
        //.....
        public DrawAction(char type_, Rectangle rect_, Color color_)
        { type = type_; rect = rect_; color = color_; }
    }
