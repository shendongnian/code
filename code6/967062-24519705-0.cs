        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Collections;
        namespace ConsoleApplication1
        {
        public class Program
        {
        private static double doubleHypotenuse = 0;
        private static int adjacent = 1;
        private static int opposite = 1;
        private static int limit = 200;
        private static int count = 0;
        public static void Main(string[] args)
        {
            
            TriangleLogic triLogic = new TriangleLogic();
            List<Triangle> triangleList = new List<Triangle>();
            List<Triangle> trianglePlus1 = new List<Triangle>();
            while (adjacent < limit)
            {
                opposite = 1;
                while (opposite < limit)
                {
                    doubleHypotenuse = triLogic.intRightAngle(adjacent, opposite);
                    if (doubleHypotenuse % 1 == 0)
                    {
                        if (!triLogic.isAlreadyValidTriangle(adjacent, opposite, triangleList))
                        {
                            triangleList.Add(new Triangle(adjacent, opposite, (int)Convert.ToInt32(doubleHypotenuse)));
                        }
                        
                        count++;
                    }
                    opposite++;
                }
                adjacent++;
            }
            Console.WriteLine("The following are integer triangles");
            triangleList.ForEach(delegate(Triangle pytag)
            {
                if ((pytag.IntHypotenuse - pytag.IntOpposite) == 1)
                {
                    trianglePlus1.Add(new Triangle(pytag.IntAdjacent, pytag.IntOpposite, pytag.IntHypotenuse));
                }
                Console.WriteLine(pytag.IntAdjacent + ", " + pytag.IntOpposite + " and " + pytag.IntHypotenuse);
            });
            Console.WriteLine("the number of squares is " + count);
            Int32 length = triangleList.Count;
            Console.WriteLine("the length of the list is " + length);
            Console.WriteLine("");
            Console.WriteLine("the List of triangles with the hypotenuse 1 ");
            Console.WriteLine("more than the opposite");
            trianglePlus1.ForEach(delegate(Triangle pytagPlus1)
            {
                Console.WriteLine(pytagPlus1.IntAdjacent + ", " + pytagPlus1.IntOpposite + " and " + pytagPlus1.IntHypotenuse);
            });
            Int32 lengthPlus1 = trianglePlus1.Count;
            Console.WriteLine("the length of the list is " + lengthPlus1);
        }
    }
    }
