    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace TestEqual
    {
        class Program
        {
            static float[] values = new float[] { 3.0000000000f, 2.0000000000f, 11.0000000000f, -11.0000000000f, -5.0000010000f, -10.0000000000f, 3.0000000000f, 2.0000000000f, 3.0000000000f, 2.0000000000f, 11.0000000000f, -11.0000000000f, -10.0000000000f, -11.0000400000f, 3.0000000000f, 2.0000000000f, 7.0000000000f, 6.0000000000f, -7.0000000000f, -10.0000000000f, 10.0000000000f, -10.0000000000f, 11.0000000000f, 9.9999550000f, -8.0000000000f, -9.9999980000f, 3.0000000000f, 2.0000000000f };
            static void Main(string[] args)
            {
                var distinct = values.Distinct(new KDFloatComparer(0.001f)).OrderBy(d => d).ToArray();
                Console.WriteLine("Valores distintos: ");
            
                foreach (var f in distinct)
                    Console.WriteLine(f);
                Console.ReadKey();
            }
            public class KDFloatComparer : EqualityComparer<float>
            {
                public readonly float InternalEpsilon = 0.001f;
                public KDFloatComparer(float epsilon)
                    : base()
                {
                    InternalEpsilon = epsilon;
                }
                // http://stackoverflow.com/a/31587700/393406
                public override bool Equals(float a, float b)
                {
                    float absoluteA = Math.Abs(a);
                    float absoluteB = Math.Abs(b);
                    float absoluteDifference = Math.Abs(a - b);
                    if (a == b)
                    {
                        return true;
                    }
                    else if (a == 0 || b == 0 || absoluteDifference < InternalEpsilon)
                    {
                        // a or b is zero or both are extremely close to it.
                        // Relative error is less meaningful here.
                        return absoluteDifference < InternalEpsilon;
                    }
                    else
                    {
                        // Use relative error.
                        return absoluteDifference / (absoluteA + absoluteB) < InternalEpsilon;
                    }
                    return true;
                }
                public override int GetHashCode(float value)
                {
                    return value.GetHashCode();
                }
            }
            public class FComparer : IEqualityComparer<float>
            {
                public bool Equals(float x, float y)
                {
                    var dif = Math.Abs(x - y);
                    if ((x == 0 || y == 0) && dif < float.Epsilon)
                        return true;
                    if (Math.Sign(x) != Math.Sign(y))
                        return false;
                    return dif < float.Epsilon;
                }
                public int GetHashCode(float obj)
                {
                    return obj.GetHashCode();
                }
            }
        }
    }
