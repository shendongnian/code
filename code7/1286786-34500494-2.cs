    public class ShapeFactory
    {
        enum PossibleShapes {CIRCLE, 
                        SQUARE, 
                        TRIANGLE, // c# allows you to do this (extra comma) on constructors, not sure about Enums, and helps with reducing 'bad' line changes in git/etc.
                        };
        public IShape GetShape(PossibleShapes whichShape)
        {
            IShape s = null;
    
            switch (shapeCode)
            {
            case PossibleShapes.SQUARE : s = new Square(color, thickness);
                break;
            case PossibleShapes.TRIANGLE: s = new Triangle(thickness);
                break;
            case PossibleShapes.CIRCLE: s = new Circle(color);
                break;
            }
    
            return s;
        }
    }
