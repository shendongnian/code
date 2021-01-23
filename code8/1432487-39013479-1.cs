        [TestMethod]
        public void Date_Convert()
        {
            string mydate = "13/05/2016";
            DateTime myConvertedDate = DateTime.ParseExact(mydate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Assert.AreEqual(13, myConvertedDate.Day);
            Assert.AreEqual(5, myConvertedDate.Month);
            Assert.AreEqual(2016, myConvertedDate.Year);
        }
