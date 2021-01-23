    public class SequenceVerifyer
    {
        public MockSequence Sequence { get; private set; } = new MockSequence();
    
        public Action NextCallback()
        {
            var callNo = setupCount++;
            return () => { AssertCallNo(callNo);};
        }
        public void VerifyAll()
        {
            Assert.AreEqual(setupCount, executionCount, $"less calls ({executionCount}) executed than previously set up ({setupCount}).");
        }
    
        private int executionCount = 0;
        private int setupCount = 0;
    
        private void AssertCallNo(int expectedCallNo)
        {
            Assert.AreEqual(executionCount, expectedCallNo, $"order of call is wrong. this call is marked with No ({expectedCallNo}), but ({executionCount}) was expected.");
            executionCount++;
        }
    }
