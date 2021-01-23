        [TestMethod]
        public void TestStackOverflowCondition()
        {
            var data = new List<int> { 
                1, 2, 1, 2, 3, 3, 1, 2, 3, 4, 1, 2, 3, 4, 5, 6 
            };
            EnumerateAndPrintResults(data);
        }
