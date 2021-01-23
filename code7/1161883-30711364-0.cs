    abstract class Base
    {
        public abstract int Field { get; set; }
    }
    class Derived : Base
    {
        public override int Field { get; set; }
    }
