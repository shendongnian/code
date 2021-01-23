    public abstract class AbstracClass 
    {
        public abstract int MustIMplementThis(string param1);
    }
    public class ChildClass : AbstracClass
    {
    
        public override int MustIMplementThis(string param1)
        {
            throw new NotImplementedException();
        }
    }
