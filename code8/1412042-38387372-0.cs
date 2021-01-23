    using System.Numerics;
    using MathNet.Numerics;
    class Program
    {
        static void Main()
        {
            double d = -1, c = 0, b = 0, a = 1;
            var roots = FindRoots.Cubic(d, c, b, a);
            Complex root1 = roots.Item1;
            Complex root2 = roots.Item2;
            Complex root3 = roots.Item3;
        }
    }
