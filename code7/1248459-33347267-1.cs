    [TestFixture]
    public class FooBarTests : PageTestBase
    {
        // Make sure to initialize the driver in the constructor or SetUp method,
        // depending on your preferences
        
        [Test]
        public void Some_test_name_goes_here()
        {
            UITest(() =>
            {
                // Do your test steps here, including asserts etc.
                // Any exceptions will be caught by the base class
                // and screenshots will be taken
            });
        }
        [TearDown]
        public void TearDown()
        {
            // Close and dispose the driver
        }
    }
