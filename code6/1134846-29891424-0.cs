    interface IA
    {
      string Print();
    }
    
    interface IB
    {
      string Print();
    }
    
    
    public abstract class A : IA
    {
        IA.Print() { return "A"; }
    }
    
    public class B : IB, A
    {
        IB.Print() { return "B"; }
    }
