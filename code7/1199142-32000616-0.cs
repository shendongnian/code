     public class TestBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return new DependencyObject();
        }
    }
