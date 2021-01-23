    public class MyController
    {
        private SomeType _bookManager;
        public SomeType BookManager
        {
            get
            {
                 if (_bookManager == null)
                     _bookManager = new SomeType();
                 return _bookManager;
            }
            set { _bookManager = value; }
        }
        public async Task<ActionResult> Archive()
        {
            // IMPORTANT: Use "BookManager" instead of "_bookManager"
        }
    }
