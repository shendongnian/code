        [TestMethod]
        public void TestQuoteSearch()
        {
            List<char> quotes = new List<char> { '\'', '‘', '’' };
            List<string> names = new List<string> { "Smith", "O\'Brien", "O‘Malley", "Jones" };
            var quotedNames = names.Where(name => quotes.Any(qoute => name.Contains(qoute)));
            Assert.IsTrue(quotedNames.Contains("O‘Malley"));
            Assert.IsFalse(quotedNames.Contains("Smith"));
        }
