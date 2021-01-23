    class Shape
    {
        public bool closedPath;
        public Shape(bool closedPath)
        {
            this.closedPath = closedPath;
        }
    }
    class Circle : Shape
    {
        public Circle()
            : base(true)
        {
        }
    }
    class Line : Shape
    {
        public Line()
            : base(false)
        {
        }
    }
