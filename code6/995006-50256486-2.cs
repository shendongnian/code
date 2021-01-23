    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void IsValidAddress_Test_AbnCoin()
        {
            var Address = "1QF4NgxgF86SH4dizN4JPHMprWBHbKdSmJ";
            Assert.IsTrue(Validator.IsValidAddress(Address));
        }
        [TestMethod]
        public void IsValidAddress_Test_BitCoin()
        {
            var Address = "1QF4NgxgF86SH4dizN4JPHMprWBHbKdSmJ";
            Assert.IsTrue(Validator.IsValidAddress(Address));
        }
        [TestMethod]
        public void IsValidAddress_Test_BitCoinTestnet()
        {
            var Address = "mpMwtvqaLQ4rCJsnoceAoLShKb4inV8uUi";
            Assert.IsTrue(Validator.IsValidAddress(Address));
        }
        [TestMethod]
        public void IsValidAddress_Test_BitCoinGold()
        {
            var Address = "GRiDm3LEjXAMMJhWaYqN8nSjuU7PSqZMUe";
            Assert.IsTrue(Validator.IsValidAddress(Address));
        }
        [TestMethod]
        public void IsValidAddress_Test_Dash()
        {
            var Address = "Xb9Edf28eYR9RRDwj7MBBVBc5vgGgT2vLV";
            Assert.IsTrue(Validator.IsValidAddress(Address));
        }
        [TestMethod]
        public void IsValidAddress_Test_Litecoin()
        {
            var Address = "LUdpZosHDP3M97ZSfvj3p1qygNFMNpXBr3";
            Assert.IsTrue(Validator.IsValidAddress(Address));
        }
        [TestMethod]
        public void IsValidAddress_Test_False_TooShort()
        {
            var Address = "1QF4NgxgF86SH4dizN4JPHMprWBHbKdSm";
            Assert.IsFalse(Validator.IsValidAddress(Address));
        }
        [TestMethod]
        public void IsValidAddress_Test_False_TooLong()
        {
            var Address = "1QF4NgxgF86SH4dizN4JPHMprWBHbKdSmJS";
            Assert.IsFalse(Validator.IsValidAddress(Address));
        }
        [TestMethod]
        public void IsValidAddress_Test_False_BadChecksum()
        {
            var Address = "1QF5NgxgF86SH4dizN4JPHMprWBHbKdSmJ";
            Assert.IsFalse(Validator.IsValidAddress(Address));
        }
        [TestMethod]
        public void IsValidAddress_False_NotBase58()
        {
            var Address = "lQF4NgxgF86SH4dizN4JPHMprWBHbKdSmJ";
            Assert.IsFalse(Validator.IsValidAddress(Address));
        }
    }
}
