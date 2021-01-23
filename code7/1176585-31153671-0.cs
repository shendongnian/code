    internal class Foo
    {
        private bool FooIsEnabled;
        public void Bar()
        {
            Execute(() => Debug.WriteLine("Bar"));
        }
        public void Baz()
        {
            Execute(() => Debug.WriteLine("Baz"));
        }
        public void Bat()
        {
            Execute(() => Debug.WriteLine("Bat"));
        }
        public void Execute(Action operation)
        {
            if (operation == null)
                throw new ArgumentNullException("operation");
            if (!FooIsEnabled)
                return;
            operation.Invoke();
        }
    }
