    public sealed class SubClass : BaseClass
    {
        public SubClass(int value)
            : base(0)
        {
            Value = value;
        }
        public override int Value { get; set; } 
    }
