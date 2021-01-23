        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]// remove this attribute to pass the test 
        public void CheckValidAmount()
        {
            SampleTestClass sp = new SampleTestClass();
            double dd = sp.CheckValidAmount("RamKumar", 1.0);
            Assert.AreEqual(dd, 9.0); 
        }
