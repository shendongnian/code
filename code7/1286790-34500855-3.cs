    public class ShapeBuildDirector
    {
        public Shape Construct()
        {
            ShapeBuilder builder = new ShapeBuilder();
            builder.GetCircle();
    
            builder.SetColour(2);
            builder.SetThickness(4);
    
            return builder.GetResult();
        }
    }
