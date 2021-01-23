    public class Unit : IEquatable<Unit>
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
        #region IEquatable Members
        /// <summary>
        /// Equality overrides from <see cref="System.Object"/>
        /// </summary>
        /// <param name="obj">The object to compare this with</param>
        /// <returns>False if object is a different type, otherwise it calls <code>Equals(Unit)</code></returns>
        public override bool Equals(object obj)
        {
            if(obj is Unit)
            {
                return Equals((Unit)obj);
            }
            return false;
        }
        /// <summary>
        /// Checks for equality among <see cref="Unit"/> classes
        /// </summary>
        /// <param name="other">The other <see cref="Unit"/> to compare it to</param>
        /// <returns>True if equal</returns>
        public bool Equals(Unit other)
        {
            return M==other.M
                &&L==other.L
                &&T==other.T
                &&x.Equals(other.x);
        }
        /// <summary>
        /// Calculates the hash code for the <see cref="Unit"/>
        /// </summary>
        /// <returns>The int hash value</returns>
        public override int GetHashCode()
        {
            return (((17*23+M.GetHashCode())*23+L.GetHashCode())*23+T.GetHashCode())*23+x.GetHashCode();
        }
        #endregion
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
