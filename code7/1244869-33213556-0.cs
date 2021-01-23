    [TestFixture]
    public class TestCase3Final : BaseTestFixture
...
    public class BaseTestFixture {
     [TestFixtureSetup]
     public void SetupStuff() {
      // set up driver here using a [TestFixtureSetup] attribute
      // it will be run for every class that inherits from it.
     }
    }
