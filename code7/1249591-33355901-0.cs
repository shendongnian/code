    public interface IFoo
    {
        IEnumerable<int> GetFoos();
    }
    public class Foo : IFoo
    {
        public IEnumerable<int> GetFoos()
        {
            return Enumerable.Range(1, 10);
        }
    }
    public class Bar
    {
        private readonly IFoo foo;
        public Bar(IFoo foo)
        {
            this.foo = foo;
        }
        public IEnumerable<int> SquareFoos()
        {
            foreach(var item in foo.GetFoos())
            {
                yield return item * item;
            }
        }
    }
