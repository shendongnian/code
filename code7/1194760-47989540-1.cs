    namespace TestApp.Test
    {
        [TestClass]
        public class UnitTest1
        {
            // This enables the runner to set the TestContext. It gets updated for each test.
            public TestContext TestContext { get; set; }
            [TestMethod]
            public void TestMethod1()
            {
                // Arrange
                String expectedName = "TestMethod1";
                String expectedUrl = "http://localhost";
    
                // Act
                String actualName = TestContext.TestName;
                // The properties are read from the .runsettings file
                String actualUrl = TestContext.Properties["webAppUrl"].ToString();
    
                // Assert
                Assert.AreEqual(expectedName, actualName);
                Assert.AreEqual(expectedUrl, actualUrl);
            }
    
            [TestMethod]
            public void TestMethod2()
            {
                // Arrange
                String expectedName = "TestMethod2";
    
                // Act
                String actualName = TestContext.TestName;
    
                // Assert
                Assert.AreEqual(expectedName, actualName);
            }
        }
    }
