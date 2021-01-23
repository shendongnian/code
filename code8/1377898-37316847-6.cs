    interface IShape
    {
        double Perimiter { get; }
    }
    
    interface IClosedFigure : IShape
    {
        double Area { get; }
    }
    interface IHasPoints
    {
        IEnumerable<Point> GetPoints();
    }
    
    sealed class Circle : IClosedFigure { /* ... */ }
    sealed class Polyline : IShape, IHasPoints { /* ... */ }
