    public class Scorer
    {   
        public enum ScoringCategory {FullHouse}
        public int getScore(ScoringCategory category)
        {
            return 1; 
        }
    }
    [TestClass]
    public class ScoringTests
    {
        [TestMethod]
        public void TestFullHouse()
        {                 
            // create an instance                   
            var scorerInstance = new Scorer();
            // call instance method getScore
            int myScore = scorerInstance.getScore(Scorer.ScoringCategory.FullHouse);
        }
    }
