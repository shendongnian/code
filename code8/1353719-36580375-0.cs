        /// <summary>
        /// The non-default constructor that initializes
        /// necessary instances of objects that are being used
        /// </summary>
        public VerifyViewUsing() { }
    
    
        /// <summary>
        /// Our simple country display test.
        /// </summary>
        [InlineData(FunctionalTestBase.DriverType.Chrome)]
        [InlineData(FunctionalTestBase.DriverType.FireFox)]
        [InlineData(FunctionalTestBase.DriverType.IE)]
        [Theory]
        public void TestADisplayedForACountry(FunctionalTestBase.DriverType testBaseType) {
            TestBase testBase = new TestBase(testBaseType);
            testBase.TestADisplayedForACountry();
        }
    
