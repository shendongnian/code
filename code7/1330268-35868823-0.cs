    using Caliburn.Micro;
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        // More overrides here...
    
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MvvmCameraDemo.ViewModels.ShellViewModel>();
        }
    }
