     [TestClass]
    public class CompareDataTest
    {
        private TaughtUnit firstGrade;
        private TaughtUnit secondGrade;
        private void GenerateTerms(int firstTerm, int secondTerm, out TaughtUnit firstGrade, out TaughtUnit secondGrade)
        {
            firstGrade = new TaughtUnit("foo");
            secondGrade = new TaughtUnit("bar");
        }
        [TestMethod]
        public void CompareResultsTest1()
        {
            GenerateTerms(..., ..., ..)
            firstGrade.Percentage.Add("GRADE", 38);
            secondGrade.Percentage.Add("GRADE", 70);
            // rest of other things you want to set specific to the test.
            Assert.AreEqual(0, messages.Count);
        }
    }
