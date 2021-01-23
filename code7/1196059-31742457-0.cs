    class Base
    {
        public virtual async Task<int> Method()
        {
            await Task.Delay(10);
            return 42;
        }
    }
    
    class Derived : Base
    {
        // next line produces warning
        public override async Task<int> Method()
        {
            return 42;
        }
    }
