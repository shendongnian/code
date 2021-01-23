    // Add an AcceptVisitor method to the IGeometryObject interface:
    public interface IGeometryObject
    {
        GeoJSONObjectType Type { get; }
        void AcceptVisitor(IShapeProcessor visitor);
    }
    // Update each concrete shape class to include the new AcceptVisitor method:
    public void AcceptVisitor(IShapeProcessor visitor)
    {
        visitor.ProcessShape(this);
    }
    // Add an IShapeProcessor interface to the GeoJSON.NET project:
    public interface IShapeProcessor
    {
        void ProcessShape(Polygon shape);
        void ProcessShape(MultiPoint shape);
        void ProcessShape(LineString shape);
        // ...additional shape support...
    }
    // Update your existing class to implement the IShapeProcessor interface,
    // and then change your code to do something like:
    feature.Geometry.AcceptVisitor(this);
