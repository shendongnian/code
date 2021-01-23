    class Derived : Base
    {
        public override Task<int> Method()
        {
            return Task.FromResult(42);
        }
    }
