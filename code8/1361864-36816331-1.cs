    public class Base
    {
        public const int LinesCount = 1;
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
            int index = base.LinesCount;
            OtherProperty = int.Parse(lines[index++]);
        }
        public int OtherProperty { get; }
    }
