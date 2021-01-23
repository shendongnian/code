    public interface IViewModel<T> { }
    public class MainViewModel : IViewModel<Someclass>
    {
        public MainViewModel(IViewModel<SomeOtherClass> userControlViewModel)
        {
            this.UserControlViewModel = userControlViewModel;
        }
        public IViewModel<SomeOtherClass> UserControlViewModel { get; private set; }
    }
    public class UserControlViewModel : IViewModel<SomeOtherClass>
    {
        private readonly ISomeService someDependency;
        public UserControlViewModel(ISomeService someDependency)
        {
            this.someDependency = someDependency;
        }
    }
