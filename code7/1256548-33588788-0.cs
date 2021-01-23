    public struct Direction : IEquatable<Direction>
    {
        short xstep;
        short ystep;
        public static Direction N { get { return new Direction(0, 1); } }
        public static Direction E { get { return new Direction(1, 0); } }
        public static Direction S { get { return new Direction(0, -1); } }
        public static Direction W { get { return new Direction(-1, 0); } }
        public static IEnumerable<Direction> Directions
        {
            get
            {
                yield return N;
                yield return E;
                yield return S;
                yield return W;
            }
        }
        Direction(int x, int y)
        {
            this.xstep = checked((short)x);
            this.ystep = checked((short)y);
        }
        public int XStep { get { return xstep; } }
        public int YStep { get { return ystep; } }
        public Direction Left { get { return new Direction(-YStep, XStep); } }
        public Direction Right { get { return new Direction(YStep, -XStep); } }
        public override bool Equals(object obj)
        {
            if (obj is Direction)
            {
                var other = (Direction)obj;
                return xstep == other.XStep && ystep == other.YStep;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (XStep.GetHashCode() | (YStep << 16).GetHashCode());
        }
        #region IEquatable<Direction> Members
        public bool Equals(Direction other)
        {
            return this.xstep == other.xstep && this.ystep == other.ystep;
        }
        #endregion
        public static Direction operator -(Direction direction)
        {
            return new Direction(direction.XStep, direction.YStep);
        }
        public static bool operator ==(Direction first, Direction second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(Direction first, Direction second)
        {
            return !(first == second);
        }
        public override string ToString()
        {
            if (this == Direction.N)
                return "N";
            if (this == Direction.E)
                return "E";
            if (this == Direction.S)
                return "S";
            if (this == Direction.W)
                return "W";
            return string.Format("({0},{1}}", XStep.ToString(NumberFormatInfo.InvariantInfo), YStep.ToString(NumberFormatInfo.InvariantInfo));
        }
    }
