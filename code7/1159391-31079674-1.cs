    public sealed class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
            ConventionManager.AddElementConvention<PasswordBox>(
                PasswordBoxHelper.BoundPasswordProperty,
                "Password",
                "PasswordChanged");
        }
        // other bootstrapper stuff here
    }
