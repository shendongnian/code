    public class TestEventArgs : EventArgs
    {
        public static new readonly TestEventArgs Empty = new TestEventArgs();
        public bool UpdatedValue { get; private set; }
        TestEventArgs() : this(false) { }
        public TestEventArgs(bool updatedValue)
        {
            this.UpdatedValue = updatedValue;
        }
        public event EventHandler<TestEventArgs> TestHappening;
        private void MyMethod()
        {
            EventHandler<TestEventArgs> eh = TestHappening;
            if (eh != null)
            {
                eh(this, TestEventArgs.Empty);
            }
        }
    }
