    public class MyController
    {
        private SomeType _bookManager;
        public SomeType BookManager
        {
            get { return _bookManager; }
            set { _bookManager = value; }
        }
        public async Task<ActionResult> Archive()
        {
            // your method
        }
    }
