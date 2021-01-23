    class SomeClass
    {
        private SomeType _state;
        public SomeClass(SomeType state, SomeEventHandler eventHandler)
        {
            _state = state;
            someEventHandler += MyDelegate;
        }
        private void MyDelegate(object sender, EventArgs e)
        {
            // do something with _state
        }
    }
