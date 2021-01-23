    public interface IModel
    {
        Foo GetFoo();
    }
    public class AccountModel : IModel
    {
        public Foo GetFoo()
        {
            // whatever
        }
    }
    public class ProductModel : IModel
    {
        public Foo GetFoo()
        {
            // whatever
        }
    }
