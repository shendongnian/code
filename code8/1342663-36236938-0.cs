    public interface ITest
    {
        void Run();
    }
    public class Test : ITest
    {
        void ITest.Run() => Run();
        public virtual int Run()
        {
            return 1; // doesn’t matter, will be replaced by our mock
        }
    }
