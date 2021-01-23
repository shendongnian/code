    public struct GradeValue // : IComparable, IFormattable, ...
    {
        private readonly double m_value;
        private GradeValue(double value)
        {
            m_value = value;
        }
        public static implicit operator GradeValue(double value)
        {
            return new GradeValue(value);
        }
        public static implicit operator double(GradeValue c)
        {
            return c.m_value;
        }
        public override string ToString()
        {
            // ToDo: What is the logic???
            return "1-";
        }
    }
