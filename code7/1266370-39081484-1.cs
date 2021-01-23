    [TestFixture, RequiresSTA]
    public class BootstrapperTest
    {
       // Declare private variables here
       Bootstrapper b;
       /// <summary>
       /// This gets called once at the start of the 'TestFixture' attributed
       /// class. You can create objects needed for the test here
       /// </summary>
       [TestFixtureSetUp]
       public void FixtureSetup()
       {
          b = new Bootstrapper();
          b.Run();
       }
       /// <summary>
       /// Assert container is created
       /// </summary>
       [Test]
       public void ShellInitialization()
       {
          Assert.That(b.Container, Is.Not.Null);
       }
       /// <summary>
       /// Assert module catalog created types
       /// </summary>
       [Test]
       public void ShellModuleCatalog()
       {
          IModuleCatalog mod = ServiceLocator.Current.TryResolve<IModuleCatalog>();
          Assert.That(mod, Is.Not.Null);
         
          // Check that all of your modules have been created (based on mod.Modules)
       }
    }
