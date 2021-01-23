       public static IEnumerable<object[]> DriverTypes {
            get {
                // Or this could read from a file. :)
                return new[]
                {
                    new object[] {  FunctionalTestBase.DriverType.Chrome },
                    new object[] {  FunctionalTestBase.DriverType.IE},
                    new object[] {  FunctionalTestBase.DriverType.FireFox}
                };
            }
        }
        /// <summary>
        /// Verifies that Brucellosis is displayed in the Disease List for
        /// Zimbabwe
        /// </summary>
        [Theory, MemberData("DriverTypes")]
        public void TestClickingADiseaseLinkDisplaysACreatePage(FunctionalTestBase.DriverType testBaseType) {
            TestBase testBase = new TestBase(testBaseType);
            testBase.TestClickingADiseaseLinkDisplaysACreatePage();
        }
