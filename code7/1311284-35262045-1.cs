    public class SomeInterfaceImpl : ISomeInterface
    {
        private Control _control;
        public string Foo { get; private set; }
        public void Bar()
        {
        }
        public SomeInterfaceImpl(Control control)
        {
            _control = control;
        }
    }
