    public abstract class BaseClass<TClass> where TClass : BaseClass<TClass>
    {
        public string A {get ; set; }
        public TClass SetPropertyA(string value)
        {
            this.A=value;
            return this as TClass;
        }
    }
