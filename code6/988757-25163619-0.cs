    public abstract class A
    {
       public int Min { get; protected set; }
       public int Max { get; protected set; }
       public A(int low, int high)
       {
           this.Min = low;
           this.Max = high;
       }
       protected abstract A CreateInstance(int low, int high);
    
       public object Clone()
       {
          return this.CreateInstance(this.Min,this.Max);
       }
    }
    
    public class B:A
    {
       public B(int low, int high)
          : base(low,high)
       {
       }
       protected override A CreateInstance(int low, int high)
       {
          return new B(low,high);     
       }
    }
