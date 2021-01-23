        [TestMethod]
        public void TestGetNumberCommasAndPlusSign()
        {
            Regex r = new Regex(@"[\d,\+]+");
            string result = "";
            foreach (Match m in r.Matches("%2%,%12%,%115%+%55%,..."))
                result += m.Value;
            Assert.AreEqual("2,12,115+55,", result);
        }
