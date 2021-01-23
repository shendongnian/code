    public abstract class BaseEntity<T, TKey> where T : BaseEntity<T, TKey> { }
    public interface IAggregateRoot { }
    public interface IUnitOfWork
    {
        void Commit();
    }
    public interface IWriteUnitOfWork : IUnitOfWork
    {
        void Insert<T>(T aggregateRoot)
            where T : BaseEntity<T, Guid>, IAggregateRoot;
    }
    public abstract class Entity<T, TKey> : BaseEntity<T, TKey>
        where T : BaseEntity<T, TKey>
    { }
    public class Customer : Entity<Customer, Guid>, IAggregateRoot { }
    public abstract class Context : IWriteUnitOfWork
    {
        public void Insert<T>(T aggregateRoot)
            where T : BaseEntity<T, Guid>, IAggregateRoot
        { }
        public void Commit() { }
    }
    public class MyContext : Context { }
    public class ExampleThatIWant
    {
        public void Something()
        {
            IWriteUnitOfWork myContext = new MyContext();
            var customer = new Customer();
            myContext.Insert(customer);
        }
    }
