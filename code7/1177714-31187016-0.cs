    class InnerClass
    {
        public event EventHandler SomeEvent;
    }
    class WrapperClass
    {
        private InnerClass innerClass = new InnerClass();
        public event EventHandler SomeEventWrapped
        {
            add { innerClass.SomeEvent += value; }
            remove { innerClass.SomeEvent -= value; }
        }
    }
