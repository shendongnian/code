    public class Base
    {
        public Item(string[] lines)
        {
            Id = int.Parse(lines[0]);
        }
        public int Id { get; }
    }
    public class Inherited : Base
    {
        public Inherited(string[] lines) : base(lines)
        {
            OtherProperty = int.Parse(lines[1]);
        }
        public int OtherProperty { get; }
    }
