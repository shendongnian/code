    public interface ICopyable<in T>
        where T : class
    {
        void Copy(T source);
    }
    public abstract class AggregateRoot : ICopyable<AggregateRoot>
    {
        public virtual void Copy(AggregateRoot newAggregateRoot) 
        {
           // my code here.
        }
    }
