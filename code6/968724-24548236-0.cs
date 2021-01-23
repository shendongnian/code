    public partial class BaseClass<T>
    {
        public virtual void Save()
        {
            // only support the T : BaseClass<T> scenario, so
            // we expect "this" to be a T
            CREATE<T>.New((T)(object)this);
        }
    }
