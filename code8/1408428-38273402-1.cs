    public interface IContract
    {
        // It is a must to implement this method in classes
        void MustImplement();
    }
    
    public abstract class BaseClass
    {
        // Just signature, No implementation. It is a must to implement.
        public abstract void IAmAbstract();
    
        public virtual void IAmVirtual()
        {
            Console.WriteLine("I provide default implementation");
        }
    }
    
    public class DerivedClass : BaseClass, IContract
    {
        public override void IAmAbstract()
        {
            Console.WriteLine("provides Abstract Method implementation In Derived Class");
        }
    
        // It is optional to override this method
        public override void IAmVirtual()
        {
            // class default implementation
            base.IAmVirtual();
    
            Console.WriteLine("provides Additional virtual Method implementation In Derived Class");
        }
    
        public void MustImplement()
        {
            Console.WriteLine("provides Interface Method implementation In Derived Class");
        }
    }
