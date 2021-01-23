    public sealed class r_type
    {
        private double Value;
        public static readonly r_type c001_a1 = new r_type(0.1);
        public static readonly r_type c001_a2 = new r_type(0.2);
        public static readonly r_type c001_a4 = new r_type(0.4);
        public static readonly r_type c001_a8 = new r_type(0.8);
        private r_type(double d)
        {
            Value = d;
        }
        public static implicit operator double(r_type d)
        {
            return d.Value;
        }
    }
