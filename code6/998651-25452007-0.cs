    public abstract class BaseClass<T> : IEquatable<T>
        where T : BaseClass<T>
    {
        public int ID { get; set; }
        public bool Equals(T other)
        {
            return
                other != null &&
                other.ID == this.ID;
        }
    }
    public sealed class Child1 : BaseClass<Child1>
    {
        string Child1Prop { get; set; }
        public bool Equals(Child1 other)
        {
            return base.Equals(other);
        }
    }
    public sealed class Child2 : BaseClass<Child2>
    {
        string Child2Prop { get; set; }
        public bool Equals(Child2 other)
        {
            return base.Equals(other);
        }
    }
