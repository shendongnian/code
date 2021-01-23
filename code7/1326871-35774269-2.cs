    protected internal class TestA
    {
        private TestB _testB;
    
        private class TestB
        {
        }
    
        public TestA()
        {
            _testB = new TestB();
        }
    }
