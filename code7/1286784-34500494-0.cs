    public class ShapeFactory
    {
        public class PossibleShapes{
             public final static int SQUARE = 1; 
             public final static int TRIANGLE = 2; 
             public final static int CIRCLE = 3; 
        }
        public IShape GetShape(int shapeCode)
        {
            IShape s = null;
    
            switch (shapeCode)
            {
            case PossibleShapes.SQUARE : s = new Square(color, thickness);
                break;
            case PossibleShapes.Triangle: s = new Triangle(thickness);
                break;
            case PossibleShapes.Circle: s = new Circle(color);
                break;
            }
    
            return s;
        }
    }
