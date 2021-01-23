    public class OrderRule: IEquatable<OrderRule>
    {
        public OrderRule(string property)
        {
            this.Property = property;
        }
        public OrderDirection Direction { get; set; }
        public String Property { get; }
        public OrderRule Rule { get; set; }
        public bool Equals(OrderRule other)
        {
            return (other != null && other.Property == this.Property);
        }
        public override int GetHashCode()
        {
            return Property?.GetHashCode() ?? int.MinValue;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if(ReferenceEquals(this, obj))
                return true;
            OrderRule other = obj as OrderRule;
            return this.Equals(other);
        }
    }
