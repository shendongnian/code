    enum AreaEnum
    {
        Square,
        Rectangle,
        Triangle,
        Circle,
    };
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Please select what type of shape you wish to find the area of:\n1. Square\n2. Rectangle\n3. Triangle\n4. Circle\n");
            int x = Convert.ToInt16(Console.ReadLine());
            AreaEnum myValueAsEnum = (AreaEnum)x;
            Calculate(myValueAsEnum);
        }
        static double Calculate(AreaEnum a)
        {
            int x, i, j;
            i = 0;
            j = 0;
            Area area = new Area();
            switch (a)
            {
                case AreaEnum.Square:
                    {
                     return Area.Square(i);
                    }
                case AreaEnum.Rectangle:
                    {
                        return Area.Rectangle(j, i);
                    }
                case AreaEnum.Triangle:
                    {
                        return Area.Triangle(j, i);
                    }
                case AreaEnum.Circle:
                    {
                        return Area.Circle(i);
                    }
                default:
                    {
                        Console.WriteLine("That is an invalid choice");
                        return 0;
                        
                    }
            }
        }
    }
