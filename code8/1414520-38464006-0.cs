    public class MyObject : ICloneable
    {
        public string Property { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
