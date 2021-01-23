    public interface IParent<T, Id> where T : IParent<T, Id>
    {
        Child<T, Id> GetChild();
    }
    
    public class Child<T, Id> where T : IParent<T, Id>
    {
        public T Parent;
    
        public Child<T, Id> GetChild()
        {
            throw new NotImplementedException();
        }
    }
