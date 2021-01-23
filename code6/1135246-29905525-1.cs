    var container = new UnityContainer();
    container.AddNewExtension<AutoFakeExtension>();
    
    // The IFoo dependency is provided automatically using FakeItEasy
    var test = container.Resolve<Test>();
    
    public interface IFoo
    {
    }
    
    public class Test
    {
        public Test(IFoo foo)
        {
        }
    }
