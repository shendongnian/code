    public abstract class BaseClass
    {
        public abstract string IAM { get; }
    }
    public interface ITestInterface<out T> where T : BaseClass
    {
        T GetSomething();
    }
