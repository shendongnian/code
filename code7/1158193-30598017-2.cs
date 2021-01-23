    public class TestEventArgs : EventArgs
    {
        public static new readonly TestEventArgs True = new TestEventArgs(true);
        public static new readonly TestEventArgs False = new TestEventArgs(false);
        public bool UpdatedValue { get; private set; }
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
