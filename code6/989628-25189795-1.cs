    public class Unit 
    {
        readonly int M, L, T; // base unit powers. For example Area: (M=0, L=2, T=0)
        readonly double x; // base unit factor. For example 1 km = (1000)*m
        public Unit(int M, int L, int T, double factor)
        {
            this.M=M;
            this.L=L;
            this.T=T;
            this.x=factor;
        }
        public Unit(Unit other)
        {
            this.M=other.M;
            this.L=other.L;
            this.T=other.T;
            this.x=other.x;
        }
        public int[] Dimension { get { return new int[] { M, L, T }; } }
        public double Factor { get { return x; } }
        public bool IsConvertibleTo(Unit other) { return M==other.M&&L==other.L&&T==other.T; }
        public double FactorTo(Unit target)
        {
            if(IsConvertibleTo(target))
            {
                return Factor/target.Factor;
            }
            throw new ArgumentException("Incompatible units in target.");
        }
        public override string ToString()
        {
            return string.Format("{0}(M:{1},L:{2},T:{3})", Factor, M, L, T);
        }
        public static Unit operator*(double relative, Unit unit)
        {
            return new Unit(unit.M, unit.L, unit.T, relative*unit.Factor);
        }
        public static Unit operator/(Unit unit, double divisor)
        {
            return new Unit(unit.M, unit.L, unit.T, unit.Factor/divisor);
        }
        public static Unit operator*(Unit unit, Unit other)
        {
            return new Unit(
                unit.M+other.M,
                unit.L+other.L,
                unit.T+other.T,
                unit.Factor*other.Factor);
        }
        public static Unit operator/(Unit unit, Unit other)
        {
            return new Unit(
                unit.M-other.M,
                unit.L-other.L,
                unit.T-other.T,
                unit.Factor/other.Factor);
        }
        public static Unit operator^(Unit unit, int power)
        {
            return new Unit(
                unit.M*power,
                unit.L*power,
                unit.T*power,
                Math.Pow(unit.Factor, power));
        }
        public static readonly Unit Meter=new Unit(0, 1, 0, 1.0);
        public static readonly Unit Millimeter=0.001*Meter;
        public static readonly Unit Inch=25.4*Millimeter;
        public static readonly Unit Foot=12*Inch;
        public static readonly Unit Yard=3*Foot;
        public static readonly Unit Second=new Unit(0, 0, 1, 1.0);
        public static readonly Unit Minute=60*Second;
        public static readonly Unit Hour=60*Minute;
        public static readonly Unit Kilogram=new Unit(1, 0, 0, 1.0);
        public static readonly Unit PoundMass=0.453592*Kilogram;
        public static readonly Unit Newton=Kilogram*(Meter/(Second^2));
        public static readonly Unit PoundForce=4.44822162*Newton;
    }
