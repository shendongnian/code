    public interface IEntity { }
    public abstract class Entity<TEntity> : IEntity where TEntity : IEntity {
      public abstract TEntity doStuff(TEntity e1, TEntity e2, TEntity e3);
    }
    public class Customer : Entity<Customer> {
      public override Customer doStuff(Customer c1, Customer c2, Customer c3) {
        // do stuff
        return foo;
      }
    }
