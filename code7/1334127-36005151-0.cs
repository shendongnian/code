    public abstract class IntegrationTestBase
    {
        private static bool _constructed;
        protected IntegrationTestBase()
        {
            if (_constructed)
            {
                lock (Lock)
                {
                    AssignNonStaticProperties();
                }
                return;
            }
            _constructed = true;
            // Do the stuff which was originally in the static constructor, runs only once
            ...
        }
    }
