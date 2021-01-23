    public abstract class AbstractDomainObject<T>
      where T : AbstractDomainObject
    {
        public abstract bool CanDoStuffWith(T other);
    }
    public class Customer : AbstractDomainObject<Customer>
    {
        public override bool CanDoStuffWith(Customer other)
        {
            return this.Gender != other.Gender;
        }
    }
