        [TestMethod]
        public void TestCalculationFruitSmoothie()
        {
            PointsCalculator2.Core.CalculationHelper helper = new PointsCalculator2.Core.CalculationHelper();
            int actual = helper.CalculatePoints(1, 25, 4, 6, false);
            int expect = 3;
            Assert.AreEqual(expect, actual);
        }
