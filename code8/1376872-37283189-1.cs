    public abstract class AbstractMyClass
    {
        protected AbstractMyClass(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public abstract void DoSomething();
    }
