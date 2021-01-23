        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckValidAmount_CallWithInvalidName_Throw()
        {
            SampleTestClass sp = new SampleTestClass();
            sp.CheckValidAmount("RamKumar", 1.0);
        }
