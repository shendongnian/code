    public abstract class Shape
    {
        private static readonly List<Shape> allShapes = new List<Shape>();
            
        protected Shape()
        {
            allShapes.Add(this);
        }
    }
