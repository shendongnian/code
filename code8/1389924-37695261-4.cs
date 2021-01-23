        public interface IDependency
    {
        void DoSomething();
        int Argument { get; set; }
    }
    public abstract class DependencyBase : IDependency
    {
        public DependencyBase(int argument) { Argument = argument; }
        public void DoSomething() { }
        public int Argument { get; set; }
    }
