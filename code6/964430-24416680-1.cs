    A x = new D();
    x.Test();
    
    public abstract class A
    {
        public abstract void Test();
    }
    
    public abstract class B : A
    {
        public override void Test()
        {
            Console.WriteLine("Test() in B");
        }
    }
    
    public abstract class C<T> : B
    {
        
    }
    
    public class D : C<String>
    {
        public override void Test()
        {
            base.Test(); //breakpoint hits here
        }
    }
