    class TestClass : ITest
    {
        public int TotalMarks(int engMarks, int mathMarks)
        {
            return engMarks + mathMarks;
        }
        public void AdditionalMethod()
        {
    
        }
    }
    TestClass c = new TestClass();
    c.AdditionalMethod(); //Valid
    ITest c1 = new TestClass();
    c1.AdditionalMethod(); //Invalid, compilation error
