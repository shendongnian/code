    public class Repository
    {
        /// <summary>
        /// Let's say that SaveState can return true / false OR throw some exception.
        /// </summary>
        public virtual bool SaveState(int state)
        {
            // Do some complicated stuff that you don't care about but want to mock.
            var result = false;
            return result;
        }
        public void DoSomething()
        {
            // Do something useful here and assign a state.
            var state = 0;
            var result = SaveState(state);
            // Do something useful with the result here.
        }
    }
    public class MockedRepositoryWithReturnFalse : Repository
    {
        public override bool SaveState(int state) => false;
    }
    public class MockedRepositoryWithReturnTrue : Repository
    {
        public override bool SaveState(int state) => true;
    }
    public class MockedRepositoryWithThrow : Repository
    {
        public override bool SaveState(int state) => 
            throw new InvalidOperationException("Some invalid operation...");
    }
