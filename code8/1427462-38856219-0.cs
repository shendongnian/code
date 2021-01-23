    public class ColorEnum
    {
        protected readonly string Name;
        protected readonly Color Value;
        public static readonly ColorEnum Red = new ColorEnum(Color.Red, "Red");
        public static readonly ColorEnum Green = new ColorEnum(Color.Green, "Green");
        public static readonly ColorEnum Blue = new ColorEnum(Color.Blue, "Blue");
        protected ColorEnum(Color value, string name)
        {
            Name = name;
            Value = value;
        }
        public override string ToString()
        {
            return Name;
        }
        public static implicit operator Color(ColorEnum @enum)
        {
            return @enum.Value;
        }
        public static implicit operator string(ColorEnum @enum)
        {
            return @enum.Name;
        }
    }
    public class AnotherColorEnum : ColorEnum
    {
        public static readonly ColorEnum Grey = new AnotherColorEnum(Color.Gray, "Grey");
        public static readonly ColorEnum Black = new AnotherColorEnum(Color.Black, "Black");
        public static readonly ColorEnum White = new AnotherColorEnum(Color.White, "White");
        protected AnotherColorEnum(Color value, string name) : base(value, name)
        {
        }
    }
