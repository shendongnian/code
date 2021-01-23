    public abstract class Vector<T> : LineSegment
    {
        public abstract T Magnitude { get; }
    }
    public class DimensionVector : Vector<Dimension>
    {
        public override Dimension Magnitude { get { return base.Length; } }
    }
    public class ForceUnitVector : Vector<ForceUnit>
    {
        ForceUnit magnitudeForce;
        public override ForceVector Magnitude { get { return this.magnitudeForce; } }
    }
