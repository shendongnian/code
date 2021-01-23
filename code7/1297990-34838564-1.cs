    public class SubClass<T> : Base where T : IModel
    {
        public SubClass(string name) : base(name){}
        public T Method(string parameter)
        {
            //do some stuff here and return T
            return T;
        }
    }
