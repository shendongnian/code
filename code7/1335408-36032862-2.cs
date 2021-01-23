    public class SpecialRectangle
    {
        double AreaOfRectangle { get; set; }
        double PerimeterOfRectangle { get; set; }
    }
    public SpecialRectangle Rectangle(double Length, double Width)
    {
        return new SpecialRectangle() { AreaOfRectangle = Length * Width, PerimeterOfRectangle = 2 * (Length + Width) };
    }
