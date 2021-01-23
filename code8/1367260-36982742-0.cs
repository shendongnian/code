    public abstract class BaseDirectory
    {
        
    }
    public abstract class BaseUser<TDirectory> where TDirectory : BaseDirectory
    {
        protected readonly TDirectory _dir;
        protected BaseUser(TDirectory dir)
        {
            _dir = dir;
        }
    }
    public class MyDirectory : BaseDirectory
    {
        public void SpecificMethod() { }
    }
    public class MyUser : BaseUser<MyDirectory>
    {
        public MyUser(MyDirectory dir) : base(dir)
        {
            
        }
        internal void SomeMethod()
        {
            // call specific method on type MyDirectory
            _dir.SpecificMethod();
        }
    }
