    public interface IShapeData { }
    public abstract class ShapeDataWithCorners : IShapeData
    {
        public double Width { get; set; }
    }
    public class Square : ShapeDataWithCorners { }
    public class Rectangle : ShapeDataWithCorners
    {
        public double Height { get; set; }
    }
    public class Circle : IShapeData
    {
        public double Radius { get; set; }
    }
    public class Oval : IShapeData
    {
        public double Radius1 { get; set; }
        public double Radius2 { get; set; }
    }
    public enum ShapeType
    {
        Circle,
        Oval,
        Square,
        Rectangle
    }
    public interface IShapeDataFactory
    {
        IShapeData CreateShapeData(ShapeType shapeType);
    }
    public class ShapeDataFactory : IShapeDataFactory
    {
        public IShapeData CreateShapeData(ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.Circle:
                    return new Square();
                case ShapeType.Oval:
                    return new Oval();
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Square:
                    return new Square();
                default:
                    throw new ArgumentException("invalid shape type");
            }
        }
    }
