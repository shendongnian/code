    public class Ratio : IComparable<Ratio>
    {
        public readonly int A;
        public readonly int B;
        public Ratio(int a, int b)
        {
            A = a;
            B = b;
        }
        public int CompareTo(Ratio other)
        {
            return A * other.B - B * other.A;
        }
        public static bool operator <(Ratio r1, Ratio r2)
        {
            return r1.CompareTo(r2) < 0;
        }
        public static bool operator >(Ratio r1, Ratio r2)
        {
            return r1.CompareTo(r2) > 0;
        }
        public static bool operator >=(Ratio r1, Ratio r2)
        {
            return r1.CompareTo(r2) >= 0;
        }
        public static bool operator <=(Ratio r1, Ratio r2)
        {
            return r1.CompareTo(r2) <= 0;
        }
        public static bool operator ==(Ratio r1, Ratio r2)
        {
            return r1.CompareTo(r2) == 0;
        }
        public static bool operator !=(Ratio r1, Ratio r2)
        {
            return r1.CompareTo(r2) != 0;
        }
    }
