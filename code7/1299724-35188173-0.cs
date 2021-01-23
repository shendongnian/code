     _container.Register(Component.For<ITest>()
            .LifestyleSingleton()
            .ImplementedBy<Test>());
    
    public interface ITest
    {
      
    }
    
    public class Test: ITest
    {
        private readonly IUserService _ser;
    
        public Test(IUserService ser)
        {
            _ser= ser;
        }
    }
