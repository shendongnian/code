    class AnotherTestClass : ITest
    {
        public int TotalMarks(int engMarks, int mathMarks)
        {
            return engMarks + mathMarks;
        }
    }
     ITest c1 = new AnotherTestClass();
