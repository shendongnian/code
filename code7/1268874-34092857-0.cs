    // Interface in UIAppearanceExtensibility 
    public interface IInterface1
    {
        void Method1();
    }
    // Class in UI
    public class Class1 : IInterface1
    {
        // ...
    }
    // This usage in UI will be intercepted
    IInterface1 i1 = new Class1();
    i1.Method1();
    // This usage in UI will not be intercepted
    Class1 c1 = new Class1();
    c1.Method1();
