    public class TestA : TestB
    {
        public TestB GetBase()
        {
            return (TestB)this;
        }
    
        public int GetA1()
        {
            return this.a1;
        }
    }
    protected internal class TestB
    {
        public int a1 = 0;
    }
