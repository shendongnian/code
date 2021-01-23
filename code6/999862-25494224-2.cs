    public class Class1<C> : IInterface<C>
        where C : struct
    {
        public char CompareTo(C that)
        {
            throw new NotImplementedException();
        }
    
        public C defaultValue { get; set; }
    }
    
    public interface IInterface<C> where C : struct
    {
        char CompareTo(C that);
        C defaultValue { set; get; }
    }
