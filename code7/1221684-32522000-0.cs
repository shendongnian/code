    class Asserts
    {
        private static StringBuilder _stack;
        [SetUp]
        public void SetUp()
        {
            _stack = new StringBuilder();
        }
        [TearDown]
        public void TearDown()
        {
            if (_stack.Lenght != 0) Assert.Fail(_stack.ToString());
        }
        [Test]
        public void Test()
        {
            AssertHelper(() => Assert.AreEqual(0, 0));
            AssertHelper(() => Assert.IsNotNull(null));
            AssertHelper(() => Assert.AreEqual(3, 4));
            AssertHelper(() => Assert.AreEqual(1, 1));          
        }
        private static void AssertHelper(Action assert)
        {
            try
            {
                assert();
            }
            catch (AssertionException e)
            {
                _stack.Append(e.Message);
            }
        }
    }
