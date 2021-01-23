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
    
    public class C : B
    {
        
    }
    
    public class D : C
    {
        public override void Test()
        {
            base.Test(); //breakpoint hits here
        }
    }
