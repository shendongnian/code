    public interface ICacheable
    {
        void CloneTo(ICacheable entity);
    }
    public interface ICacheable<T> : ICacheable where T : ICacheable
    {
        void CloneTo(T entity);
    }
    public abstract class Cacheable<T> : ICacheable<T> where T : ICacheable
    {
        void ICacheable.CloneTo(ICacheable entity)
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
