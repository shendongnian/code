    public class MyContext : DbContext
    {
        public MyContext() : base("connectionstringproperty") { }
    }
    
    public interface IMyContextFactory : IDbContextFactory<MyContext>
    {
    
    }
    
    public class MyContextFactory : IMyContextFactory
    {
        public MyContext Create() 
        {
            return new MyContext();
        }
    }
