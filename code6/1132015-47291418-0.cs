    /// <summary>
    /// Detects if we are running inside a unit test.
    /// </summary>
    public static class UnitTestDetector
    {
        static private bool _isInUnitTest = false;
        public static bool IsInUnitTest
        {
            get { return _isInUnitTest; }
            set { _isInUnitTest = value; }
        }
    }
