    public abstract class Shape
    {
        private static readonly List<WeakReference<Shape>> allShapes = new List<WeakReference<Shape>>();
            
        protected Shape()
        {
            allShapes.Add(new WeakReference<Shape>(this));
        }
    }
