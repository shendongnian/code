    public abstract class AbstractDomainObject<T> : IComparable<T>
      where T : AbstractDomainObject
    {
        public abstract int CompareTo(T other);
    }
    public class Customer : AbstractDomainObject<Customer>
    {
        public override int CompareTo(Customer other)
        {
            return /* */;
        }
    }
