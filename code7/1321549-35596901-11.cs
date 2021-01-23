    public class InheritanceClass1 : AbstractClass<FirstEnum>
    {
        public override string Name { get; set; }
        public override FirstEnum Value { get; set; }
        public override int GetValue () => (int)Value;
    }
