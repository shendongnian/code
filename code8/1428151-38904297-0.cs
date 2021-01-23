        [TestMethod]
        public void CountInversionTestCase1()
        {
            CountInversionTest(new int[] { 4, 3, 2, 1 }, 6);
        }
        [TestMethod]
        public void CountInversionTestCase2()
        {
            CountInversionTest(new int[] { 1, 3, 5, 2, 4, 6 }, 3);
        }
        [TestMethod]
        public void CountInversionTestCase3()
        {
            CountInversionTest(new int[] { 5, 6, 2, 3, 1, 4, 7 }, 10);
        }
        public void CountInversionTest(int[] sourceArray, int expectedInversionCount)
        {
            #region Act
            Sorter sorter = new Sorter();
            long actualInversionCount = sorter.CountInversion(sourceArray);
            #endregion
            #region Assert
            Assert.AreEqual(expectedInversionCount, actualInversionCount);
            #endregion
        }
