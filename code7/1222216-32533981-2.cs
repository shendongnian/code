        [TestMethod]
        public void TestQuoteSearch()
        {
            string searchName = "O'Brien";
            var matchingNames = names.Where(name => IsMatch(name, searchName));
            Assert.AreEqual(4, matchingNames.Count());
            Assert.IsTrue(matchingNames.Contains("O'Brien"));
            Assert.IsTrue(matchingNames.Contains("O‘Brien"));
            Assert.IsTrue(matchingNames.Contains("O’Brien"));
            Assert.IsFalse(matchingNames.Contains("Jones"));
        }
