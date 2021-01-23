    interface ISomething<T> where T:Shape
    {
        T Entity { get; set; }
    }
    public class CircleEntity : ISomething<Circle>
    {
        Circle Entity { get; set; }
    }
    
    public class SquareEntity: ISomething<Square>
    {
        Square Entity { get; set; }
    }
