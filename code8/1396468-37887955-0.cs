    class ScoreRangeAscendingTest : Test
    {
        public ScoreRangeAscendingTest(double score, Enums.TestType typeName) : base(score, typeName) { }
        public double[] ranges;
        public Enums.Rating calculateScore(double[] range) {
    	    Func<double, double, bool> cmp = (x, y) => x < y; // you can swap the comparison here, e.g. (x, y) => x > y
    		if (scoreInVeryWeakRange(cmp))
                return Enums.Rating.VeryWeak;
            else if (scoreInWeakRange(cmp))
                return Enums.Rating.Weak;
            else if (scoreInAveragelyWeakRange(cmp))
                return Enums.Rating.AveragelyWeak;
            else if (scoreInAveragelyGoodRange(cmp))
                return Enums.Rating.AveragelyGood;
            else if (scoreInGoodRange(cmp))
                return Enums.Rating.Good;
            else 
                return Enums.Rating.VeryGood;
        }
    
        private bool scoreInVeryWeakRange(Func<double, double, bool> cmp)
        {
            return cmp(this.TestScore, ranges[(int)Enums.Border.P10]);
        }
        private bool scoreInWeakRange(Func<double, double, bool> cmp)
        {
            return !cmp(TestScore, ranges[(int)Enums.Border.P10]) && cmp(TestScore, ranges[(int)Enums.Border.P25]);
        }
        private bool scoreInAveragelyWeakRange(Func<double, double, bool> cmp)
        {
            return !cmp(TestScore, ranges[(int)Enums.Border.P25]) && cmp(TestScore, ranges[(int)Enums.Border.P50]);
        }
        private bool scoreInAveragelyGoodRange(Func<double, double, bool> cmp)
        {
            return !cmp(TestScore, ranges[(int)Enums.Border.P50]) && cmp(TestScore, ranges[(int)Enums.Border.P75]);
        }
        private bool scoreInGoodRange(Func<double, double, bool> cmp)
        {
            return !cmp(TestScore, ranges[(int)Enums.Border.P75]) && cmp(TestScore, ranges[(int)Enums.Border.P90]);
        }
        private bool scoreInVeryGoodRange(Func<double, double, bool> cmp)
        {
            return (TestScore == ranges[(int)Enums.Border.P90]) || !cmp(TestScore, ranges[(int)Enums.Border.P90]);
        }
    
    }
