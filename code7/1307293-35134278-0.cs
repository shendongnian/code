    public struct Double : IComparable, IFormattable, IConvertible
            , IComparable<Double>, IEquatable<Double>
    {
        internal double m_value; // self-recursion with endless loop?
        // ...
    }
