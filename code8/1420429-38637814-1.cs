	public enum TriangleType
    {
		Scalene = 1, // no two sides are the same length
		Isosceles = 2, // two sides are the same length and one differs
		Equilateral = 3, // all sides are the same length
		Error = 4 // inputs can't produce a triangle
    }
	
	public class Triangle
	{
		public TriangleType TriangleType {get; private set;}
		public int SideA {get; private set;}
		public int SideB {get; private set;}
		public int SideC {get; private set;}
	
	    public Triangle(int a, int b, int c)
		{
			SideA = a;
			SideB = b;
			SideC = c;
			TriangleType = GetTryangleType(a,b,c);
		}
        public static TriangleType GetTriangleType(int a, int b, int c)
        {
            // There should also be a side length check
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return TriangleType.Error;
            }
            if (a == b && a == c) // These could also be their own methods
            {
                return TriangleType.Equilateral;
            }
            else if (a == b || a == c || b == c)
            {
                return TriangleType.Isosceles;
            }
            else
            {
                return TriangleType.Scalene;
            }       
        }
	}
