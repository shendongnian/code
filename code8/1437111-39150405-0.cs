    public abstract class A
    {
        public abstract void DoSomething();
    }
    
    public class B: A
    {
        public override void DoSomething() { .. do B's thing ... }
    }
    
    public class C : A
    {
        public override void DoSomething() { .. do C's thing ... }
    }
    
    
    ...
    public void Consumer(A a)
    {
        a.DoSomething(); // calls the right DoSomething, B or C.
    }
    ...
