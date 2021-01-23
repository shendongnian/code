    public interface IShapeBuilder
    {
        // Adding NotNull attribute to prevent null input argument
        void SetColor([NotNull]string colour);
    
        // Adding NotNull attribute to prevent null input argument
        void SetThickness([NotNull]int count);
    
        Shape GetShape();
    }
