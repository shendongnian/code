    public interface ISomeClass
    {
        void DoSomething();
    }
    public class SomeClass<T> : ISomeClass where T : BaseClass
    {
        private readonly IEnumerable<ITestInterface<T>> _testInterfaces;
        public SomeClass(IEnumerable<ITestInterface<T>> testInterfaces)
        {
            _testInterfaces = testInterfaces;
        }
        public void DoSomething()
        {
            foreach (var t in _testInterfaces)
            {
                var something = t.GetSomething();
                Console.WriteLine(something.IAM);
            }
        }
    }
