    public abstract class  BaseClass<T>
    {
        protected T Data { get; set; }
        protected BaseClass(T other)
        {
            this.Data = other;
        }
    }
