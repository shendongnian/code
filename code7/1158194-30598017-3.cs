    public class TestEventArgs : EventArgs
    {
        public static readonly TestEventArgs True = new TestEventArgs(true);
        public static readonly TestEventArgs False = new TestEventArgs(false);
        public bool UpdatedValue { get; private set; }
        public TestEventArgs(bool updatedValue)
        {
            this.UpdatedValue = updatedValue;
        }
        public event EventHandler<TestEventArgs> TestHappening;
        private void MyMethod()
        {
            EventHandler<TestEventArgs> eh = TestHappening;
            eh?.Invoke(this, TestEventArgs.True);
        }
    }
