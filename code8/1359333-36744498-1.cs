    public abstract class AbstractClass 
    {
        public abstract int MustIMplementThis(string param1);
    }
    public class ChildClass : AbstractClass
    {
    
        public override int MustIMplementThis(string param1)
        {
            throw new NotImplementedException();
        }
    }
