        [TestCase("user1;user2;user3;user4 user1", 5)]
        public void SplitString(string input, int expectedCount)
        {
            Assert.AreEqual(expectedCount, input.Split(new []{";"," "},StringSplitOptions.RemoveEmptyEntries));
        }
