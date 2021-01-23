    public interface ICacheable
    {
        void CloneTo(object entity);
    }
    public interface ICacheable<T> : ICacheable
    {
        void CloneTo(T entity);
    }
    public abstract class Cacheable<T> : ICacheable<T>
    {
        void ICacheable.CloneTo(object entity)
        {
            // here it can fail at runtime though
            CloneTo((T)entity);
        }
        public abstract void CloneTo(T entity);
    }
    public class MyEntity : Cacheable<MyEntity>
    {
        public override void CloneTo(MyEntity entity)
        {
            //...
        }
    }
